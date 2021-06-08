using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Rooms
{
    namespace enemyStatusConditions
    {
        public abstract class RoomTrapAndMoreAttack : Room, IChangePlayerHealth, IPlayerCanDealMoreDamage
        {
            int _healthModification; //It can be adding or substracting health.

            public int healthModification
            {
                get { return _healthModification; }
                set
                {
                    _healthModification = Mathf.Clamp(value, -100, 0);
                }
            }





            public void UpdatePlayerHealth()
            {
                _healthModification = -10;
                //_healthModification = CombatController.instance.heroDisplay.characterInstance.hp -= _healthModification;
                Debug.Log("Player receives damage: " + _healthModification);
            }

            public void PlayerDealMoreDamage()
            {
                
            }



        }
    }

}