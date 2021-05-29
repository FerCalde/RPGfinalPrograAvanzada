using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    public Monster(ScEnemy data) : base(data._EnemyName,data._attack, data._defense,data._crit,data._faceImg,data._modelImg) {
    }

    public override void TakeDamage(int ammount)
    {
        base.TakeDamage(ammount);
        if (hp == 0)
        {
            Debug.Log("Enemy " + characerName + " is dead.");
            GameObject.FindObjectOfType<EnemyWaves>().EnemyIsDead();
        }
    }

}
