using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace enemyStatusConditions
{
    public class Player : Character, IStun , IPoison, IRest
    {

        //string[] plAttacks = { "RegularAttack", "StunAttack", "PoisonAttack", "GetRest" };

        

        public Player(ScPlayer data) : base(data._playerName, data._attack, data._crit) { }
        public override void TakeDamage(int ammount)
        {
            base.TakeDamage(ammount);

            if (hp == 0)
            {
                Debug.Log("Its Fking dead");
                GameObject.FindObjectOfType<EnemyWave>().MakeNextEnemyAppear();
            }
        }

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


        public override void ChoseEnemyAction(int amount, Character targetToGo, int kindAttack)
        {

            if (kindAttack == 0)
            {
                RegularAttack(amount, targetToGo);
            }
            if (kindAttack == 1)
            {
                int turnsPoison = Mathf.RoundToInt(amount / 6);
                StunAttack(turnsPoison, targetToGo);
            }
            if (kindAttack == 2)
            {
                int turnsPoison = Mathf.RoundToInt(amount / 6);
                PoisonAttack(turnsPoison, targetToGo);
            }
            if (kindAttack == 3)
            {
                GetRest(amount);
            }
            Debug.Log(" Ataqueeeee " + kindAttack);
            /*
            for (int i = 0; i < plAttacks.Length; i++)
            {
                if (i == kindAttack)
                {
                    
                    //(plAttacks[i])(amount,targetToGo); Idea para hacerla automatizada full pero no podemos invocar metodos sin heredar de monobehaviour

                                    
                }
                if (i == 0)
                {
                    RegularAttack(amount, targetToGo);
                }
                if (i == 1)
                {
                    int turnsPoison = Mathf.RoundToInt(amount / 6);
                    StunAttack(turnsPoison, targetToGo);
                }
                if (i == 2)
                {
                    int turnsPoison = Mathf.RoundToInt(amount / 6);
                    PoisonAttack(turnsPoison, targetToGo);
                }
                if (i == 3)
                {                   
                    GetRest(amount);
                }

            }*/
        }

    }
}

