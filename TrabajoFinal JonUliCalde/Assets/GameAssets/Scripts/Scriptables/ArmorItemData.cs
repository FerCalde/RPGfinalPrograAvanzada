using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios {

    [CreateAssetMenu(fileName = "Armor", menuName = "Items/Equip/new Armor", order = 2)]
    public class ArmorItemData : EquipItemData
    {
        public int _defense;
    }
}
