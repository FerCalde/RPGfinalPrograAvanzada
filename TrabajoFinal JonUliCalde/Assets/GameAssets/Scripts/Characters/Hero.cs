using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    public Hero(ScHero data) : base(data.name, data._attack, data._defense,data._crit, data._faceImg, data._modelImg){}

    public override void TakeDamage(int ammount)
    {
        base.TakeDamage(ammount);

        if (hp == 0)
        {
            CombatController.instance.combatTurn = CombatController.CombatTurns.GAMEOVER;
        }
    }

}
