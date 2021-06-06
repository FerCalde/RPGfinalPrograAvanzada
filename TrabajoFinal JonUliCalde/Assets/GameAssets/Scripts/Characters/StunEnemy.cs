using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemyStatusConditions
{
    public class StunEnemy : Enemy, IStun
    {
        public StunEnemy(ScStunEnemy data) : base(data) { }

        public void StunAttack(int turns, Character targetToGo)
        {
            targetToGo.maxPoisonedTurns = turns;
        }
    }
}
