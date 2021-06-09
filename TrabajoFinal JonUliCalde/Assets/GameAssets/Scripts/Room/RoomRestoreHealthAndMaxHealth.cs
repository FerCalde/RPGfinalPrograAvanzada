using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public class RoomRestoreHealthAndMaxHealth : RoomRestoreHealth, IChangePlayerHealth, IPlayerMaxHealthIncreases
    {
        int _healthModification; //It can be adding or substracting health.

        int maxHpIncrement;
        public RoomRestoreHealthAndMaxHealth(ScRoomHealMaxHp data): base(data)
        {
            maxHpIncrement = data.incrementoMaxHp;
        }


        public override int healthModification
        {
            get { return _healthModification; }
            set
            {
                _healthModification = Mathf.Clamp(value, 0, 100);
            }
        }

       

        public override void UpdatePlayerHealth()
        {
            _healthModification = 10;
            Debug.Log("Player recovers: " + _healthModification);
        }

        public void IncreasePlayerMaxHealth()
        {
            //Increase player max health.
        }






    }
}

