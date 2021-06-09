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
            targetToGo.maxStunedTurns = turns;
            InfoManager.Instance.InfoChanger(name + " ha stuneado durante " + turns + " turnos.");
        }
        public override void ChoseEnemyAction(int amount, Character targetToGo)
        {
            float random = Random.Range(0, 1.1f);
            if (random > 0.3f)
            {
                RegularAttack(amount, targetToGo);
            }
            else
            {
                int turnsStun = Mathf.RoundToInt(amount / 6);
                StunAttack(turnsStun, targetToGo);
            }
        }
    }
}
