using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventarios
{
    public class Slot : MonoBehaviour
    {
        public EquipItem equipedItem = null;
        public EquipSlot slotType;
        public Image equipImg;
        public Sprite EmptyImg;

        public void AddEquip(EquipItem equip)
        {
            if (equipedItem == null)
            {
                equipedItem = equip;
                equipImg.sprite = equipedItem.image;
            }else {
                RemoveEquip();
                equipedItem = equip;
                equipImg.sprite = equipedItem.image;
            }
            
        }
        public void RemoveEquip()
        {
            if (equipedItem != null)
            {
                Inventory.instance.AddItem(equipedItem);
                equipedItem = null;
                equipImg.sprite = EmptyImg;
            }
        }
    }
}

