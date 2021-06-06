using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace enemyStatusConditions
{
    public class Player : Character
    {
        public Player(ScPlayer data) : base(data._playerName, data._attack, data._crit, data._hasPoisonAttack, data._hasStunAttack, data._hasRestAttack, data._hasNormalAttack) { }
        public override void TakeDamage(int ammount)
        {
            base.TakeDamage(ammount);

            if (hp == 0)
            {
                //CombatController.instance.combatTurn = CombatController.CombatTurns.GAMEOVER;
            }
        }
    }
}

