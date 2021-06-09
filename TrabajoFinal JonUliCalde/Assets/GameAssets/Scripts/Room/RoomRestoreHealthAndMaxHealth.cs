using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemyStatusConditions;

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
            PlayerController.Instance.GetBonusHp(_healthModification);
        }

        public void IncreasePlayerMaxHealth()
        {
            PlayerController.Instance.GetBonusMaxHp(10);
        }

        public override void ActivarRoom()
        {
            UpdatePlayerHealth();
            IncreasePlayerMaxHealth();

        }






    }
}

