using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios
{
    public class ConsumableItem : Item,IUsable
    {
        public int healAmmount;

        public ConsumableItem(ConsumableItemData data) : base(data._itemName,data._itemCost,data._itemImage)
        {
            healAmmount = data._healAmmount;
        }

        public override void PrimaryUse()
        {
            Sell(cost);
        }

        public override void SecondaryUse()
        {
            Consume();
        }

        public void Consume()
        {
            if (CombatController.instance.heroDisplay.characterInstance != null)
            {
                Inventory.instance.RemoveItem(this);
                ActionPanelController.instance.DisplayInfo(itmName + " consumed and restore " + healAmmount + " health.");
                CombatController.instance.heroDisplay.characterInstance.hp += healAmmount;
            }
            else {
                Inventory.instance.RemoveItem(this);
                Debug.Log("Error!! no player, you lost your item.");
            }
            
        }
    }
}
