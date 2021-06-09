using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemyStatusConditions;

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
            _healthModification = 10;
            PlayerController.Instance.GetBonusHp(_healthModification);
        }

        public void EnterEnemyRoom()
        {
            GameController.instance.EmpezarCombateRoom();
        }


        public override void ActivarRoom()
        {
            UpdatePlayerHealth();
            EnterEnemyRoom();

        }







    }
}

