using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Inventarios;
using UnityEngine.UI;

//Crear una clase que herede de EventArgs con los parámetros enemyWaves y enemiesPerWave;
[System.Serializable]
public class StartGameArgs : EventArgs
{
    public int salaStage;

    public int enemyWaves;
    public int enemiesPerWaves;

    public StartGameArgs(int enemiesWaves, int enemiesPerWave){
        this.enemyWaves = enemiesWaves;
        this.enemiesPerWaves = enemiesPerWave;
    }
}

public class GameController : MonoBehaviour
{
    #region singleton
    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject startPanel;
    public GameObject salasPanel;

    //public InputField wavesIField;
    //public InputField enemiesIField;

    //Crear evento EventHandler siendo su event args del tipo 
    //creado antes y llamarlo "OnCombatStart"
    public EventHandler<StartGameArgs> OnCombatStart;

    private void Start()
    {
        startPanel.SetActive(true);
        salasPanel.SetActive(false);
    }

    public void StartGame() {
        //  int waves = int.Parse(wavesIField.text);
        //  int enemies = int.Parse(enemiesIField.text);
        startPanel.SetActive(false);
        FindObjectOfType<HeroEquipmentDisplay>().OnStatsChange += CombatController.instance.heroDisplay.ActualiceDisplayData;

        //Invocar el evento OnCombatStart enviando los parámetros.
        //OnCombatStart?.Invoke(this, new StartGameArgs(waves, enemies));
        
    }

    public void StarCombat()
    {
        //OnCombatStart?.Invoke(this, new StartGameArgs(waves, enemies));
    }

}
