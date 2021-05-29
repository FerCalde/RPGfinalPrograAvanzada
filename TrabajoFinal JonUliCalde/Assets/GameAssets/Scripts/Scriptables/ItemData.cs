using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios
{
    public enum EquipSlot { HEAD, CHEST, PANTS, BOOTS, MAINHAND, OFFHAND }

    public class ItemData : ScriptableObject
    {
        public string _itemName;
        public int _itemCost;
        public Sprite _itemImage;
    }
 
}


