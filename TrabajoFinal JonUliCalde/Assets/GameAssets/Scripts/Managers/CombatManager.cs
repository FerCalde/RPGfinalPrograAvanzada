using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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
            GameOverTurn
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

            basicDamage = Random.Range((basicDamage - 5), (basicDamage + 6));
            total += basicDamage;
        }


        //Critical
        void CriticalHit(int basicDamage, float critChance, ref int total)
        {
            print("basicDamage value: " + basicDamage);


            int crit = Random.Range(1, 101);

            if (critChance > crit)
            {
                print("Crits");
                total *= 2;
            }




        }




        //miss
        void MissChance(int basicDamage, float critChance, ref int total)
        {
            print("critChance value: " + critChance);

            int missChance = Random.Range(0, 3);

            if (missChance.Equals(0)) //if missess... 33% chance
            {
                print("Misses");
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
                
            }
        }

        

        void SetCombatTurn(Character atacante, Character defensor)
        {
            StartCoroutine(DoC(atacante, defensor));
        }

        IEnumerator DoC(Character atacante, Character defensor)
        {
            CalculateAttackDamage(atacante);

            yield return new WaitForSeconds(2);

            OnNextTurn?.Invoke();

        }

        void CalculateAttackDamage(Character attacker)
        {
            totalDamage = 0;

            lifeDelegate?.Invoke(attacker.attack, attacker.critChance, ref totalDamage);
        }

        void EmpezarCombate()
        {

        }

        public void PlayerAttackRegular()
        {
            SetCombatTurn(dCPlayer.characterInstance, dCEnemy.characterInstance);
        }
        public void PlayerAttackPoisoning()
        {
            SetCombatTurn(dCPlayer.characterInstance, dCEnemy.characterInstance);

        }
        public void PlayerAttackStunning()
        {

        }
        public void PlayerAttackRest()
        {

        }

        public void EndGame()
        {
            turnoActual = TurnoCombat.GameOverTurn;
        }

        

    }

}
