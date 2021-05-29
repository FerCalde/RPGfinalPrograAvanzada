using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios
{
    public abstract class EquipItem : Item, IEquipable, IDurable
    {
        private int _durability;
        public int durability {
            get { return _durability; }
            set { _durability = Mathf.Clamp(value, 0, 100); }
        }
        
        public EquipSlot slot;

        public EquipItem(string _itemName,int _itemCost,Sprite _itemImage,int _durability,EquipSlot _slot):base(_itemName, _itemCost, _itemImage) {
            durability = _durability;
            slot = _slot;
        }

        public void Equip(EquipSlot slot) {
            HeroEquipmentDisplay.instance.EquipItem(this);
            Inventory.instance.RemoveItem(this);
            Debug.Log(itmName + " has equiped.");
        }
        public void LoseDurability(int amount) {
            durability -= amount;
            Debug.Log(itmName + " lose " + amount + " durability.");
        }
        public void Repair() {
            durability = 100;
            Debug.Log(itmName + " repaired.");
        }
        public override void SecondaryUse() {
            Equip(slot);
        }
        public override void PrimaryUse() {
            Sell(cost);
        }
    }
}
