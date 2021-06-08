using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace enemyStatusConditions
{
    public class Player : Character, IStun , IPoison, IRest
    {
        public Player(ScPlayer data) : base(data._playerName, data._attack, data._crit) { }
        public override void TakeDamage(int ammount)
        {
            base.TakeDamage(ammount);

            if (hp == 0)
            {
                //CombatController.instance.combatTurn = CombatController.CombatTurns.GAMEOVER;
            }
        }
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


        public override void ChoseEnemyAction(int amount, Character targetToGo, int kindAttack)
        {
           
        }

    }
}

