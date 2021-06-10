using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemyStatusConditions;

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

            _healthModification = -10;
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
            InfoManager.Instance.InfoChanger("Te la comiste pelotudo, pero ahora tu vida maxima es mayor");
        }



    }
}
