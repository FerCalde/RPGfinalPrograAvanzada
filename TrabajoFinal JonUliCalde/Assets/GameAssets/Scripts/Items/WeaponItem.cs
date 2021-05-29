using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios
{
    public class WeaponItem : EquipItem
    {
        public int damage;

        public WeaponItem(WeaponItemData data):base(data._itemName,data._itemCost,data._itemImage,data._durability,data._slot)
        {
            damage = data._damage;
        }
    }

}

