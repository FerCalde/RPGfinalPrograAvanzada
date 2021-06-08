using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public abstract class RoomRestoreHealth: Room, IChangePlayerHealth
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

        }



    }
}

