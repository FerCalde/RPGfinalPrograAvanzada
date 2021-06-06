using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace enemyStatusConditions
{
    public class CombatManager : MonoBehaviour
    {
        enum TurnoCombat
        {
            PlayerTurn,
            EnemyTurn,
            GameOverTurn
        }

        [SerializeField] TurnoCombat turnoActual;


        void CambiarTurno()
        {
            if (turnoActual == TurnoCombat.PlayerTurn)
            {
                turnoActual = TurnoCombat.EnemyTurn;
            }
            else if (turnoActual == TurnoCombat.EnemyTurn)
            {
                turnoActual = TurnoCombat.PlayerTurn;
            }
        }

        void SetCombatTurn(Character atacante, Character defensor)
        {

        }

        void EmpezarCombate()
        {

        }

        public void PlayerAttackRegular()
        {

        }
        public void PlayerAttackPoisoning()
        {

        }
        public void PlayerAttackStunning()
        {

        }
        public void PlayerAttackRest()
        {

        }

    }

}
