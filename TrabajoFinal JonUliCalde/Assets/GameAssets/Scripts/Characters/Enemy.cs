﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemyStatusConditions
{
    public class Enemy : Character
    {
        public Enemy(ScEnemy data) : base(data._enemyName, data._attack, data._crit)
        {

        }
        public override void TakeDamage(int ammount)
        {
            base.TakeDamage(ammount);
            if (hp == 0)
            {

               EnemyWave.Instance.MakeNextEnemyAppear();
               ProgresManager.Instance.UpdateCurrentEnemiesKilled();
                
            }
        }
        public override void ChoseEnemyAction(int amount, Character targetToGo)
        {
            RegularAttack(amount, targetToGo);
        }
    }
}

