using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemyStatusConditions
{
    public class Enemy : Character
    {
        public Enemy(ScEnemy data) : base(data._enemyName, data._attack, data._crit, data._hasPoisonAttack, data._hasStunAttack, data._hasRestAttack, data._hasNormalAttack)
        {

        }
        public override void TakeDamage(int ammount)
        {
            base.TakeDamage(ammount);
            if (hp == 0)
            {
                //GameObject.FindObjectOfType<EnemyWaves>().EnemyIsDead();
            }
        }
    }
}

