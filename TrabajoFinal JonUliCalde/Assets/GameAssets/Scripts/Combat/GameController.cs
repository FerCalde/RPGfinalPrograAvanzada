using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace enemyStatusConditions
{




    public class GameController : MonoBehaviour
    {
        public static GameController instance;
        private void Awake()
        {
            instance = this;
        }



        [SerializeField] int waves;
        [SerializeField] int enemies;
        [SerializeField] int everyHowManyWavesToHeal;

        //public event EventHandler OnStartGame;
        public event EventHandler<StartGameArgs> OnCombatStart;






        public void StartGame()
        {



            /*int waves = int.Parse(wavesIField.text);
            int enemies = int.Parse(enemiesIField.text);*/
            //startPanel.SetActive(false);
            //FindObjectOfType<HeroEquipmentDisplay>().OnStatsChange += CombatController.instance.heroDisplay.ActualiceDisplayData;


            //Invocar el evento OnCombatStart enviando los parámetros.

            //OnStartGame?.Invoke(this, new StartGameArgs(waves, enemies));
            //OnCombatStart?.Invoke(this, EventArgs.Empty);

            OnCombatStart?.Invoke(this, new StartGameArgs(waves, enemies, everyHowManyWavesToHeal));
            CombatManager.instance.dCPlayer.ActualiceDisplayData();
            InfoManager.Instance.InfoChanger("");
            InfoManager.Instance.AttackText("");
        }



    }

    public class StartGameArgs : EventArgs
    {
        public int enemyWaves;
        public int enemiesPerWaves;
        public int everyHowManyWavesToHeal;

        public StartGameArgs(int enemyWaves, int enemiesPerWave, int everyHowManyWavesToHeal)
        {
            this.enemyWaves = enemyWaves;
            this.enemiesPerWaves = enemiesPerWave;
            this.everyHowManyWavesToHeal = everyHowManyWavesToHeal;


        }


    }
}