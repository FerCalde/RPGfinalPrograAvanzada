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
            InfoManager.Instance.InfoChanger(name + " ha stuneado durante " + turns + " turnos.");
        }
        public void PoisonAttack(int turns, Character targetToGo)
        {
            targetToGo.maxPoisonedTurns = turns;
            InfoManager.Instance.InfoChanger(name + " ha envenenado durante " + turns + " turnos");
        }
        public void GetRest(int amount)
        {
            hp += amount;
            InfoManager.Instance.InfoChanger(name + " ha restaurado " + amount + " puntos de vida.");
        }
        public override void ChoseEnemyAction(int amount, Character targetToGo)
        {
            float random = Random.Range(0, 1.1f);
            if (hp >= (maxHp / 2))
            {
                if (random > 0.7f)
                {
                    GetRest(amount);
                }
                else
                {
                    float randomTwo = Random.Range(0, 1.1f);
                    if (randomTwo > 0.3f)
                    {
                        int turnsPoison = Mathf.RoundToInt(amount / 6);
                        PoisonAttack(turnsPoison, targetToGo);
                    }
                    else
                    {
                        int turnsPoison = Mathf.RoundToInt(amount / 5);
                        StunAttack(turnsPoison, targetToGo);
                    }
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
