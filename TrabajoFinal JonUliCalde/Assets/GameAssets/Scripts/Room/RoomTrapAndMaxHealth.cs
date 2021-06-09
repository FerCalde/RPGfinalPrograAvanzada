using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public class RoomTrapAndMaxHealth : RoomTrap, IChangePlayerHealth, IPlayerMaxHealthIncreases
    {
        int _healthModification; //It can be adding or substracting health.
        int maxHpIncrement;


        public override int healthModification
        {
            get { return _healthModification; }
            set
            {
                _healthModification = Mathf.Clamp(value, -100, 0);
            }
        }

        public RoomTrapAndMaxHealth(ScRoomTrapMaxHp data): base(data)
        {
            maxHpIncrement = data.incrementoMaxHp;
        }



        public override void UpdatePlayerHealth()
        {

            //_healthModification = CombatController.instance.heroDisplay.characterInstance.hp -= _healthModification;
            Debug.Log("Player receives damage: " + _healthModification);
        }

        public void IncreasePlayerMaxHealth()
        {
            
        }



    }
}
