using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public class RoomRestoreHealth: Room, IChangePlayerHealth
    {
        
        int _healthModification; //It can be adding or substracting health.

        public RoomRestoreHealth(ScRoomHeal data): base(data._roomName, data._enemies)
        {
            _healthModification = data.hpRecoveri;
        }


        public virtual int healthModification
        {
            get { return _healthModification; }
            set
            {
                _healthModification = Mathf.Clamp(value, 0, 100);
            }
        }

      

        public virtual void UpdatePlayerHealth()
        {
            _healthModification = 10;

        }



    }
}

