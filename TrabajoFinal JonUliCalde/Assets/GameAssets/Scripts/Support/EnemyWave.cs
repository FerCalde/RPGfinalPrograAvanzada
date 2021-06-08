using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


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
                object[] enemiesData = Resources.LoadAll("ScObjects/Enemies", typeof(ScEnemy));

                for (int j = 0; j < enemiesPerWave; j++)
                {
                    Enemy enemy = new Enemy(enemiesData[UnityEngine.Random.Range(0, enemiesData.Length)] as ScEnemy);
                    enemy.hp = enemy.maxHp;
                    enemyWavesArr[i].PonerALaFila(enemy);
                }
            }
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

