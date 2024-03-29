﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemyStatusConditions
{
    public class RestEnemy : Enemy, IRest
    {
        public RestEnemy(ScRestEnemy data) : base(data) { }

        public void GetRest(int amount)
        {
            hp += amount;
            InfoManager.Instance.InfoChanger(name + " ha restaurado " + amount + " puntos de vida.");
        }
        public override void ChoseEnemyAction(int amount, Character targetToGo)
        {
            float random = Random.Range(0, 1.1f);
            if (hp >= (_maxHp/2))
            {
                if (random > 0.8f)
                {
                    GetRest(amount);
                }
                else
                {
                    RegularAttack(amount, targetToGo);
                }
            }
            else
            {
                if (random < 0.5f)
                {
                    GetRest(amount);
                }
                else
                {
                    RegularAttack(amount, targetToGo);
                }
            }
        }
    }
}
