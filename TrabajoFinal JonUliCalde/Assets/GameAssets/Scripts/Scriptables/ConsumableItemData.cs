using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios {
    [CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable/new consumable", order = 1)]
    public class ConsumableItemData : ItemData
    {
        public int _healAmmount;
    }
}


