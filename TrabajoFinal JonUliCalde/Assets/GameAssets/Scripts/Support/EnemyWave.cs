using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

namespace enemyStatusConditions
{
    public class EnemyWave : SingletonTemporal<EnemyWave>
    {
        int waves;
        int enemiesPerWave;
        int actualWave = 1;
        int everyHowManyWavesToHealPlayer; //Every x seconds, player recovers health.

        GenericEnemiesQueue<Enemy>[] enemyWavesArr;


        public void Start()
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

            DisplayCombat.Instance.SwitchPanels();
            CombatManager.instance.SetearTurnoRoom();

            Init();
        }


        public void Init()
        {
            enemyWavesArr = new GenericEnemiesQueue<Enemy>[waves];
            for (int i = 0; i < waves; i++)
            {
                enemyWavesArr[i] = new GenericEnemiesQueue<Enemy>();

                /*var poisonEnemy = enemiesData.OfType<ScPoisonEnemy>();
                var stunEnemy = enemiesData.OfType<ScStunEnemy>();
                var restEnemy = enemiesData.OfType<ScRestEnemy>();
                var fullEnemy = enemiesData.OfType<ScAllAttacksEnemy>();
                var basicEnemy = enemiesData.OfType<ScEnemy>();
                
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
                foreach (ScAllAttacksEnemy e in fullEnemy)
                {
                    Enemy enemy = new FullEnemy(e);
                    enemy.hp = enemy.maxHp;
                }
                foreach (ScEnemy e in basicEnemy)
                {
                    Enemy enemy = new Enemy(e);
                    enemy.hp = enemy.maxHp;
                }*/

                for (int j = 0; j < enemiesPerWave; j++)
                {
                    int randomClass = UnityEngine.Random.Range(0, 5);
                    
                    if (randomClass == 0)
                    {
                        //enemyWavesArr[i] = new GenericEnemiesQueue<Enemy>();
                        ScEnemy[] enemiesData = Resources.LoadAll<ScEnemy>("ScObjects/Enemies");
                        Enemy enemy = new Enemy(enemiesData[UnityEngine.Random.Range(0, enemiesData.Length)] as ScEnemy);
                        enemy.hp = enemy.maxHp;
                        enemyWavesArr[i].PonerALaFila(enemy);
                    }
                    if (randomClass == 1)
                    {
                        //enemyWavesArr[i] = new GenericEnemiesQueue<Enemy>();
                        ScPoisonEnemy[] enemiesData = Resources.LoadAll<ScPoisonEnemy>("ScObjects/Enemies");
                        PoisonEnemy enemy = new PoisonEnemy(enemiesData[UnityEngine.Random.Range(0, enemiesData.Length)] as ScPoisonEnemy);
                        enemy.hp = enemy.maxHp;
                        enemyWavesArr[i].PonerALaFila(enemy);
                    }
                    if (randomClass == 2)
                    {
                        //enemyWavesArr[i] = new GenericEnemiesQueue<Enemy>();
                        ScStunEnemy[] enemiesData = Resources.LoadAll<ScStunEnemy>("ScObjects/Enemies");
                        StunEnemy enemy = new StunEnemy(enemiesData[UnityEngine.Random.Range(0, enemiesData.Length)] as ScStunEnemy);
                        enemy.hp = enemy.maxHp;
                        enemyWavesArr[i].PonerALaFila(enemy);
                    }
                    if (randomClass == 3)
                    {
                        //enemyWavesArr[i] = new GenericEnemiesQueue<Enemy>();
                        ScRestEnemy[] enemiesData = Resources.LoadAll<ScRestEnemy>("ScObjects/Enemies");
                        RestEnemy enemy = new RestEnemy(enemiesData[UnityEngine.Random.Range(0, enemiesData.Length)] as ScRestEnemy);
                        enemy.hp = enemy.maxHp;
                        enemyWavesArr[i].PonerALaFila(enemy);
                    }
                    if (randomClass == 4)
                    {
                        //enemyWavesArr[i] = new GenericEnemiesQueue<Enemy>();
                        ScAllAttacksEnemy[] enemiesData = Resources.LoadAll<ScAllAttacksEnemy>("ScObjects/Enemies");
                        FullEnemy enemy = new FullEnemy(enemiesData[UnityEngine.Random.Range(0, enemiesData.Length)] as ScAllAttacksEnemy);
                        enemy.hp = enemy.maxHp;
                        enemyWavesArr[i].PonerALaFila(enemy);
                    }


                    
                    
                }
            }
            MakeNextEnemyAppear();
        }

        public void MakeNextEnemyAppear()
        {
            StartCoroutine(NextEnemy());
        }

        IEnumerator NextEnemy()
        {


            yield return new WaitForSeconds(0.5f);

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
                    PlayerController.Instance.vida = CombatManager.instance.dCPlayer.characterInstance.hp;
                    CombatManager.instance.EndCombat();
                    
                }
            }

          
        }

    }
}

