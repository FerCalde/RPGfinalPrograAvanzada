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
            InfoManager.Instance.InfoChanger(name + " ha envenenado durante " + turns + " turnos");
        }
        public override void ChoseEnemyAction(int amount, Character targetToGo)
        {
            float random = Random.Range(0, 1.1f);
            if(random > 0.3f)
            {
                RegularAttack(amount, targetToGo);
            }
            else
            {
                int turnsPoison = Mathf.RoundToInt(amount / 5);
                PoisonAttack(turnsPoison, targetToGo);
            }
        }
    }
}
