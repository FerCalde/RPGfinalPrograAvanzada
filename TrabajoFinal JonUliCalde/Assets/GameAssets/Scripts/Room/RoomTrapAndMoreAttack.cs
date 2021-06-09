using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Rooms
{
    namespace enemyStatusConditions
    {
        public class RoomTrapAndMoreAttack : RoomTrap, IChangePlayerHealth, IPlayerCanDealMoreDamage
        {
            int _healthModification; //It can be adding or substracting health.
            int _moreAttack;

            public override int healthModification
            {
                get { return _healthModification; }
                set
                {
                    _healthModification = Mathf.Clamp(value, -100, 0);
                }
            }

            public RoomTrapAndMoreAttack(ScRoomTrapMaxAttack data): base(data)
            {
                _moreAttack = data.incrementoMaxAttack;
            }



            public override void UpdatePlayerHealth()
            {

                //_healthModification = CombatController.instance.heroDisplay.characterInstance.hp -= _healthModification;
                Debug.Log("Player receives damage: " + _healthModification);
            }

            public void PlayerDealMoreDamage()
            {
                
            }



        }
    }

}