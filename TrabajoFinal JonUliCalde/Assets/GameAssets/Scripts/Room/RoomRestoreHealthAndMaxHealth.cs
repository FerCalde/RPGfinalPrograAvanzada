using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public abstract class RoomRestoreHealthAndMaxHealth : Room, IChangePlayerHealth, IPlayerMaxHealthIncreases
    {
        int _healthModification; //It can be adding or substracting health.

        public int healthModification
        {
            get { return _healthModification; }
            set
            {
                _healthModification = Mathf.Clamp(value, 0, 100);
            }
        }

       

        public void UpdatePlayerHealth()
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

