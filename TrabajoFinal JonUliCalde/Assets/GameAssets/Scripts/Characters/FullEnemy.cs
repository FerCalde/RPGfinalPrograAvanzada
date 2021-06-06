using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemyStatusConditions
{
    public class FullEnemy : Enemy, IStun, IPoison, IRest
    {
        public FullEnemy(ScAllAttacksEnemy data) : base(data) { }
        public void StunAttack(int turns, Character targetToGo)
        {
            targetToGo.maxStunedTurns = turns;
        }
        public void PoisonAttack(int turns, Character targetToGo)
        {
            targetToGo.maxPoisonedTurns = turns;
        }
        public void GetRest(int amount)
        {
            hp += amount;
        }
    }
}
