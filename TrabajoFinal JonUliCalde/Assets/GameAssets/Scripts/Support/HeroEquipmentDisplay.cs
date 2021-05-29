using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

namespace Inventarios
{
    public class HeroEquipmentDisplay : MonoBehaviour
    {
        #region singleton
        public static HeroEquipmentDisplay instance;
        private void Awake()
        {
            instance = this;
        }
        #endregion

        public delegate void StatsChangeHandler();
        public event StatsChangeHandler OnStatsChange;

        [HideInInspector]
        public Hero heroInstance;

        public GameObject characterPanel;
        public GameObject inventoryPanel;

        public List<Slot> chInventory = new List<Slot>();
        public Image heroImage;
        public Dropdown heroDropD;
        public Button startBtn;
        public Text attackTxt;
        public Text defenseTxt;
        int baseAttack;
        int baseDefense;

        private void Start()
        {
            characterPanel.gameObject.SetActive(true);
            inventoryPanel.gameObject.SetActive(false);
            
            chInventory.AddRange(characterPanel.GetComponentsInChildren<Slot>());
           
            GameController.instance.OnCombatStart += HideContent;
            GameController.instance.OnCombatStart += SetHeroInCharDisplay;
        }

        public void updateAtackDefense() {
            heroInstance.attak = baseAttack;
            heroInstance.defense = baseDefense;

            foreach (Slot s in chInventory) {
                WeaponItem w = s.equipedItem as WeaponItem;
                if (w != null) { heroInstance.attak += w.damage; }
                ArmorItem a = s.equipedItem as ArmorItem;
                if (a != null) { heroInstance.defense += a.defense; }
            }

            attackTxt.text = heroInstance.attak.ToString();
            defenseTxt.text = heroInstance.defense.ToString();

            OnStatsChange?.Invoke();
        }

        public void EquipItem(EquipItem equip)
        {
            foreach (Slot s in chInventory) {
                if (s.slotType == equip.slot) {
                    s.AddEquip(equip);
                }
            }
            updateAtackDefense();
        }

        public void DesequipItem(Slot slot) {
            slot.RemoveEquip();
            updateAtackDefense();
        }

        public void ChangeHeroDisplay() {

            heroDropD.interactable = false;
            startBtn.interactable = true;
            inventoryPanel.SetActive(true);

            GenerateHeroInstance(heroDropD.value);
            updateAtackDefense();
            heroImage.sprite = heroInstance.model;

        }

        public void GenerateHeroInstance(int heroIndex) {
            object heroData;
            switch (heroIndex) {
                case 1:
                    heroData = Resources.Load("Heros/Mage");
                    heroInstance = new Hero(heroData as ScHero);
                    break;
                case 2:
                    heroData = Resources.Load("Heros/Archer");
                    heroInstance = new Hero(heroData as ScHero);
                    break;
                case 3:
                    heroData = Resources.Load("Heros/Warrior");
                    heroInstance = new Hero(heroData as ScHero);
                    break;
            }
            baseAttack = heroInstance.attak;
            baseDefense = heroInstance.defense;
        }

        void HideContent(object sender, StartGameArgs e) {
            characterPanel.SetActive(false);
            inventoryPanel.SetActive(false);
        }

        void SetHeroInCharDisplay(object sender, StartGameArgs e) {
            CombatController.instance.heroDisplay.characterInstance = heroInstance;
            CombatController.instance.heroDisplay.ActualiceDisplayData();
        }

        private void OnDestroy()
        {
            GameController.instance.OnCombatStart -= HideContent;
            GameController.instance.OnCombatStart -= SetHeroInCharDisplay;
        }
    }
}


