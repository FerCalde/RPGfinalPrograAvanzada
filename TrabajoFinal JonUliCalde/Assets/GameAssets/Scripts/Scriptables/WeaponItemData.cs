using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Inventarios {

    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Equip/new Weapon", order = 2)]
    public class WeaponItemData : EquipItemData
    {
        public int _damage;
    }
}
   