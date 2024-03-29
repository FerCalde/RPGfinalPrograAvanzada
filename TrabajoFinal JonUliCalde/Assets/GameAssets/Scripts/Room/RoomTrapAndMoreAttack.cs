﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemyStatusConditions;



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

                _healthModification = -10;
                PlayerController.Instance.GetBonusHp(_healthModification);
            }

            public void PlayerDealMoreDamage()
            {
                PlayerController.Instance.GetBonusAttack(5);
            }

            public override void ActivarRoom()
            {
                UpdatePlayerHealth();
                PlayerDealMoreDamage();

                InfoManager.Instance.InfoChanger("Te la comiste pelotudo, pero ahora tu ataque es mas potente");
            }



        }
    }

}