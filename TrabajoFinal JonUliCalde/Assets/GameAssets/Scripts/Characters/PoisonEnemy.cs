using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemyStatusConditions
{
    public class PoisonEnemy : Enemy, IPoison
    {
        public PoisonEnemy(ScPoisonEnemy data) : base(data){}

        public void PoisonAttack(int turns, Character targetToGo)
        {
            targetToGo.maxPoisonedTurns = turns;
        }
        public override void ChoseEnemyAction(int amount, Character targetToGo)
        {
            float random = Random.Range(0, 1);
            if(random > 0.5f)
            {
                RegularAttack(amount, targetToGo);
            }
            else
            {
            }
        }
    }
}
