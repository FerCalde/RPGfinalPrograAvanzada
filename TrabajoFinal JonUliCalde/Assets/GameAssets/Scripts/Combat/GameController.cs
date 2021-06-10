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
        int roomAmount;

        //public event EventH   andler OnStartGame;
        public event EventHandler<StartGameArgs> OnCombatStart;
        public event EventHandler<StartRoomArgs> OnRoomStart;



        public void RandomizeRooms()
        {
            OnRoomStart?.Invoke(this, new StartRoomArgs(roomAmount));
        }






        public void StartRoom()
        {
            //RandomizeSalas();
            //Evento onSalasStart igual que el combat start

            //Estos ifs pueden ir en el Room initializer mejor pa qque opase de sala y tal
            //if(Room is hasEnemies-> EmpezarCombate() para que se meta en combate con waves y enemigos 
            //sino pasar siguiente sala
        }


        public void EmpezarCombateRoom()
        {

            RandomizeWaves();
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


        public void RandomizeWaves()
        {
            waves = 2;// UnityEngine.Random.Range(1, 5);
            enemies = 2;//UnityEngine.Random.Range(1, 5);
            everyHowManyWavesToHeal = 1;// UnityEngine.Random.Range(1, 5);

            //InfoManager.Instance.CombatWaveEnemiesInfo(waves, enemies);

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

    public class StartRoomArgs: EventArgs
    {
        public int roomAmount;

        public StartRoomArgs(int _roomAmount)
        {
            this.roomAmount = _roomAmount;
        }
    }

}