using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios
{
    public abstract class Item : ISelleable
    {
        public string itmName;
        private int _cost;
        public int cost {
            get { return _cost; }
            set {_cost = Mathf.Clamp(value,0,999); }
        }
        public Sprite image;

        protected Item(string _name,int _cost,Sprite _image){
            itmName = _name;
            cost = _cost;
            image = _image;
        }

        public abstract void PrimaryUse();
        public abstract void SecondaryUse();
        public void Sell(int amount) {
            Inventory.instance.AddGold(amount);
            Inventory.instance.RemoveItem(this);
            Debug.Log(itmName + " sold for " + amount + " Gold.");
        }

        public static implicit operator Item(WeaponItemData v)
        {
            throw new NotImplementedException();
        }
    }
}


