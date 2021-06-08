﻿using System.Collections;
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
        public override void ChoseEnemyAction(int amount, Character targetToGo)
        {
            float random = Random.Range(0, 1);
            if (hp >= (maxHp / 2))
            {
                if (random > 0.8f)
                {
                    GetRest(amount);
                }
                else
                {
                    float randomTwo = Random.Range(0, 1);
                    if (randomTwo > 0.3f)
                    {
                        int turnsPoison = Mathf.RoundToInt(amount / 6);
                        PoisonAttack(turnsPoison, targetToGo);
                    }
                    else
                    {
                        int turnsPoison = Mathf.RoundToInt(amount / 6);
                        StunAttack(turnsPoison, targetToGo);
                    }
                }
            }
            else
            {
                if (random < 0.6f)
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