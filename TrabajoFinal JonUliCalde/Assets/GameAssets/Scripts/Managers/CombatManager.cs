using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rooms;


namespace enemyStatusConditions
{




    public class CombatManager : MonoBehaviour
    {

        public delegate void NextTurn();
        public event NextTurn OnNextTurn;


        public delegate void LifeDelegate(int basicDamage, float critChance, ref int total);
        public event LifeDelegate lifeDelegate;


        public DisplayCharacter dCPlayer;
        public DisplayCharacter dCEnemy;

        int plAttack = 0;

        int totalDamage = 0;

        #region singleton
        public static CombatManager instance;
        private void Awake()
        {
            instance = this;
        }
        #endregion

        public enum TurnoCombat
        {
            PlayerTurn,
            EnemyTurn,
            GameOverTurn,
            EndCombatTurn
        }

        public TurnoCombat turnoActual;


        bool hasMissed;
        private void Start()
        {
            hasMissed = false;
            OnNextTurn += CambiarTurno;

            lifeDelegate += BasicHit;
            lifeDelegate += CriticalHit;
            lifeDelegate += MissChance;


        }

        void BasicHit(int basicDamage, float critChance, ref int total)
        {

            basicDamage = Mathf.RoundToInt(Random.Range((basicDamage - 5), (basicDamage + 6)));
            total += basicDamage;
            InfoManager.Instance.AttackText("");
        }


        //Critical
        void CriticalHit(int basicDamage, float critChance, ref int total)
        {
            //print("basicDamage value: " + basicDamage);

            float crit = Random.Range(0, 1);

            if ((critChance) < crit)
            {
                InfoManager.Instance.AttackText("CRITICAL!");
                //print("Crits");
                total *= 2;
            }

        }




        //miss
        void MissChance(int basicDamage, float critChance, ref int total)
        {
            //print("critChance value: " + critChance);

            int missChance = Random.Range(0, 1);

            if ((critChance * 0.5f) < missChance) //if missess... 33% chance
            {
                //print("Misses");
                InfoManager.Instance.AttackText("MISS!");
                hasMissed = true;
                total = 0;
            }
            else
                hasMissed = false;

            //if character is stunned, missChance = 66%; 
        }



        void CambiarTurno()
        {
            if (turnoActual == TurnoCombat.PlayerTurn)
            {
                turnoActual = TurnoCombat.EnemyTurn;
                SetCombatTurn(dCEnemy.characterInstance, dCPlayer.characterInstance); //Setteamos el turno del enemigo
            }
            else if (turnoActual == TurnoCombat.EnemyTurn)
            {
                turnoActual = TurnoCombat.PlayerTurn;
                DisplayCombat.Instance.EnableButtonsAttack();
            }
            else if (turnoActual == TurnoCombat.EndCombatTurn)
            {
                InfoManager.Instance.InfoChanger("Has ganado el combate!");
                DisplayCombat.Instance.SwitchPanels();
            }
            else if (turnoActual == TurnoCombat.GameOverTurn)
            {
                InfoManager.Instance.InfoChanger("GAME OVER!");
            }
        }

        public void SetearTurnoRoom()
        {
            turnoActual = TurnoCombat.EnemyTurn;
            print("GOGOGOGOG");
            CambiarTurno();
        }


        void SetCombatTurn(Character atacante, Character defensor)
        {
            StartCoroutine(DoC(atacante, defensor));
        }

        IEnumerator DoC(Character atacante, Character defensor)
        {
            //Comprobar estado del Atacante y updatea sus "constantes"
            atacante.CheckIsStuned();
            atacante.CheckIsPoisoned(2);

            CalculateAttackDamage(atacante);

            if (atacante.isStuned)
            {
                totalDamage = Mathf.RoundToInt(totalDamage * 0.5f);
            }
            //(atacante == dCPlayer.characterInstance) ? atacante.ChoseEnemyAction(totalDamage, defensor, plAttack) : atacante.ChoseEnemyAction(totalDamage, defensor);

            if (atacante == dCPlayer.characterInstance)
            {
                atacante.ChoseEnemyAction(totalDamage, defensor, plAttack);


            }
            else if (atacante != dCPlayer.characterInstance)
            {
                atacante.ChoseEnemyAction(totalDamage, defensor);
            }

            //TEXT CRITICAL 

             if (totalDamage > dCPlayer.characterInstance.attack)
             {
                 InfoManager.Instance.AttackText("CRITICAL!");
             }
             else if (totalDamage <= dCPlayer.characterInstance.attack && totalDamage > 0)
             {

                 InfoManager.Instance.AttackText("");
             }
             else if (totalDamage == 0)
             {

                 InfoManager.Instance.AttackText("MISS!");
             }




            yield return new WaitForSeconds(2);

            OnNextTurn?.Invoke();

        }

        void CalculateAttackDamage(Character attacker)
        {
            totalDamage = 0;

            lifeDelegate?.Invoke(attacker.attack, attacker.critChance, ref totalDamage);
        }


        public void PlayerSelectAttack(int indexAttack)
        {
            plAttack = indexAttack;
            //dCPlayer.characterInstance.ChoseEnemyAction(dCPlayer.characterInstance.attack, dCEnemy.characterInstance, indexAttack);
            SetCombatTurn(dCPlayer.characterInstance, dCEnemy.characterInstance);

        }

        public void EndCombat()
        {
            turnoActual = TurnoCombat.EndCombatTurn;
        }

        public void EndGame()
        {
            turnoActual = TurnoCombat.GameOverTurn;
            StartCoroutine(RestartScene());
        }
        IEnumerator RestartScene()
        {

            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(0);
        }


    }

}
