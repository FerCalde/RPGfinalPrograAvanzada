using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios
{
    public class KeyItem : Item, IDoorInteractive
    {
        public KeyItem(KeyItemData data):base(data._itemName, data._itemCost, data._itemImage)
        {

        }
        public override void SecondaryUse()
        {

        }
        public override void PrimaryUse()
        {

        }
    }
}

