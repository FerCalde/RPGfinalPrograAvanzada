using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

namespace enemyStatusConditions
{
    public class EnemyWave : MonoBehaviour
    {
        int waves;
        int enemiesPerWave;
        int actualWave = 1;
        int everyHowManyWavesToHealPlayer; //Every x seconds, player recovers health.

        GenericEnemiesQueue<Enemy>[] enemyWavesArr;

        // Start is called before the first frame update
        private void Start()
        {
            //combatPanel.SetActive(false);
            GameController.instance.OnCombatStart += ShowContent;
        }





        void ShowContent(object sender, StartGameArgs e)
        {
            this.waves = e.enemyWaves;
            enemiesPerWave = e.enemiesPerWaves;
            this.everyHowManyWavesToHealPlayer = e.everyHowManyWavesToHeal;
            //combatPanel.SetActive(true);
            Init();
        }


        void Init()
        {
            enemyWavesArr = new GenericEnemiesQueue<Enemy>[waves];
            for (int i = 0; i < waves; i++)
            {
                enemyWavesArr[i] = new GenericEnemiesQueue<Enemy>();
                ScEnemy[] enemiesData = Resources.LoadAll<ScEnemy>("ScObjects/Enemies");
                
                var poisonEnemy = enemiesData.OfType<ScPoisonEnemy>();
                var stunEnemy = enemiesData.OfType<ScStunEnemy>();
                var restEnemy = enemiesData.OfType<ScRestEnemy>();
                
                foreach (ScPoisonEnemy e in poisonEnemy) 
                {
                    Enemy enemy = new PoisonEnemy(e);
                    enemy.hp = enemy.maxHp;
                }
                foreach(ScStunEnemy e in stunEnemy)
                {
                    Enemy enemy = new StunEnemy(e);
                    enemy.hp = enemy.maxHp;
                }
                foreach (ScRestEnemy e in restEnemy)
                {
                    Enemy enemy = new RestEnemy(e);
                    enemy.hp = enemy.maxHp;
                }

                /*for (int j = 0; j < enemiesPerWave; j++)
                {
                    Enemy enemy = new Enemy(enemiesData[UnityEngine.Random.Range(0, enemiesData.Length)] as ScEnemy);
                    
                    enemyWavesArr[i].PonerALaFila(enemy);
                }*/
            }
            MakeNextEnemyAppear();
        }

        public void MakeNextEnemyAppear()
        {
            StartCoroutine(NextEnemy());
        }

        IEnumerator NextEnemy()
        {


            yield return new WaitForSeconds(3);

            if (enemyWavesArr[actualWave - 1].count > 0)
            {
                CombatManager.instance.dCEnemy.characterInstance = enemyWavesArr[actualWave - 1].QuitarDeLaFila();
                CombatManager.instance.dCEnemy.ActualiceDisplayData();

                /*if ((everyHowManyWavesToHealPlayer % actualWave).Equals(0)) //Si el resto es 0. Es decir, si por ejemplo 3/3...
                {
                    //Actualizamos texto de información
                    //Recuperamos vida jugador.
                    //yield return new WaitForSeconds(3);
                }*/

                
            }
            else
            {
                actualWave++;
                if (enemyWavesArr.Length >= actualWave)
                {
                    CombatManager.instance.dCEnemy.characterInstance = enemyWavesArr[actualWave - 1].QuitarDeLaFila();
                    CombatManager.instance.dCEnemy.ActualiceDisplayData();
                }
                else
                {
                    CombatManager.instance.EndGame();
                    
                }
            }
        }

    }
}

