using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios
{
    public class ArmorItem : EquipItem
    {
        public int defense;

        public ArmorItem(ArmorItemData data):base(data._itemName, data._itemCost, data._itemImage, data._durability, data._slot) {
            defense = data._defense;
        }
    }
}

