using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyWaves : MonoBehaviour
{
    public GameObject combatPanel;

    //Array de filas genéricas de monsters
    GenericEnemyQueue<Monster>[] enemyWavesArr;

    int waves;
    int enemiesPerWave;
    int actualWave =1;


    private void Start()
    {
        combatPanel.SetActive(false);
        GameController.instance.OnCombatStart += ShowContent;
    }

    void ShowContent(object sender, StartGameArgs e) {
        waves = e.enemyWaves;
        enemiesPerWave = e.enemiesPerWaves;
        combatPanel.SetActive(true);
        Init();
    }

    void Init()
    {
        enemyWavesArr = new GenericEnemyQueue<Monster>[waves];
        for (int i = 0; i < waves; i++) {
            enemyWavesArr[i] = new GenericEnemyQueue<Monster>();
            object[] enemiesData = Resources.LoadAll("Enemies",typeof(ScEnemy));

            for (int j = 0; j < enemiesPerWave; j++) {
                Monster enemy = new Monster(enemiesData[UnityEngine.Random.Range(0, enemiesData.Length)] as ScEnemy);
                enemyWavesArr[i].PonerALaFila(enemy);
            }
        }
        StartCoroutine(NextEnemy());
    }

    public void EnemyIsDead() {
      StartCoroutine( NextEnemy());
    }

    IEnumerator NextEnemy() {
        yield return new WaitForSeconds(3);

        if (enemyWavesArr[actualWave - 1].count > 0)
        {
            CombatController.instance.enemyDisplay.characterInstance = enemyWavesArr[actualWave - 1].QuitarDeLaFila();
            CombatController.instance.enemyDisplay.ActualiceDisplayData();

        }
        else
        {
            actualWave++;
            if (enemyWavesArr.Length >= actualWave)
            {
                CombatController.instance.enemyDisplay.characterInstance = enemyWavesArr[actualWave - 1].QuitarDeLaFila();
                CombatController.instance.enemyDisplay.ActualiceDisplayData();
            }
            else
            {
                CombatController.instance.combatTurn = CombatController.CombatTurns.GAMEOVER;
            }
        }
    }

}
