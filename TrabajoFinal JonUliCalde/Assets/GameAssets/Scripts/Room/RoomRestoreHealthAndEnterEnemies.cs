using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public class RoomRestoreHealthAndEnterEnemies : RoomRestoreHealth, IChangePlayerHealth, IEnemiesRoom
    {
        int _healthModification; //It can be adding or substracting health.


        public RoomRestoreHealthAndEnterEnemies(ScRoomHealEnemies data) : base(data) { }
       

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
            
            Debug.Log("Player recovers: " + _healthModification);
        }

        public void EnterEnemyRoom()
        {
            //Go to enemies room.
        }







    }
}

