using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Inventarios {
    public class Inventory : MonoBehaviour
    {
        #region singleton
        public static Inventory instance; //Acceso estático
        private void Awake()
        {
            instance = this;
        }
        #endregion

        public enum DisplayFilter {ALL,CONSUMABLES,EQUIPABLES, IMPORTANTKEYS }
        public DisplayFilter filter;
        
        //Referencias UI
        [SerializeField]
        private Transform content;
        [SerializeField]
        private Text goldTxt;

        //Referencia al prefab del Botón Item
        [SerializeField]
        private GameObject itemBtnPref;

        public List<Item> bag = new List<Item>();
        public List<Item> displayedItems = new List<Item>();
        int goldAmount = 0;

        private void Start()
        {
            ConstructAllItems();
        }

        public void AddGold(int amount) {
            goldAmount += amount;
            goldTxt.text = goldAmount.ToString();
        }

        public void AddItem(Item item)
        {
            bag.Add(item);
            UpdateDisplayedItems();
        }

        public void RemoveItem(Item item) {
            bag.Remove(item);
            UpdateDisplayedItems();
        }

        void ShowItem(Item item)
        {
            GameObject go = Instantiate(itemBtnPref, content);
            go.GetComponent<ItemButton>().item = item;
        }

        void UpdateDisplayedItems() {
            EmptyAllDisplay();
            switch (filter) {
                case DisplayFilter.ALL:
                    foreach (Item i in bag) { ShowItem(i); }
                    break;
                case DisplayFilter.CONSUMABLES:
                    var consumables = bag.OfType<ConsumableItem>();
                    foreach (Item i in consumables) { ShowItem(i); }
                    break;
                case DisplayFilter.EQUIPABLES:
                    var Equip = bag.OfType<EquipItem>();
                    foreach (Item i in Equip) { ShowItem(i); }
                    break;
            }
        }

        void EmptyAllDisplay() {
            displayedItems.Clear();
            ItemButton[] visualBtn = content.GetComponentsInChildren<ItemButton>();
            foreach (ItemButton ib in visualBtn)
            {
                Destroy(ib.gameObject);
            }
        }

        private void ConstructAllItems()
        {
            ItemData[] itemsData = Resources.LoadAll<ItemData>("Items/");
            var consumables = itemsData.OfType<ConsumableItemData>();
            var weapons = itemsData.OfType<WeaponItemData>();
            var armor = itemsData.OfType<ArmorItemData>();

            foreach (ConsumableItemData cData in consumables)
            {
                Item item = new ConsumableItem(cData);
                AddItem(item);
            }
            foreach (WeaponItemData wData in weapons)
            {
                Item item = new WeaponItem(wData);
                AddItem(item);
            }
            foreach (ArmorItemData aData in armor)
            {
                Item item = new ArmorItem(aData);
                AddItem(item);
            }

        }

        public void BtnShowAll()
        {
            filter = DisplayFilter.ALL;
            UpdateDisplayedItems();
        }
        public void BtnShowEquipables()
        {
            filter = DisplayFilter.EQUIPABLES;
            UpdateDisplayedItems();
        }
        public void BtnShowConsumables()
        {
            filter = DisplayFilter.CONSUMABLES;
            UpdateDisplayedItems();
        }
        public void BtnShowImportantKeys()
        {
            filter = DisplayFilter.IMPORTANTKEYS;
            UpdateDisplayedItems();
        }

    }
}


