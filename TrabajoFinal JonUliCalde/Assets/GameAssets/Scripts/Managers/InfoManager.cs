using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : SingletonTemporal<InfoManager>
{
    Text infoText;
    [SerializeField] Text criticText;
    [SerializeField] Text cantEnemiesInWave;
    [SerializeField] Text cantWavesInRoom;

    private void Start()
    {
        infoText = GetComponent<Text>();
    }
    public void InfoChanger(string t)
    {
        infoText.text = t;
    }

    public void AttackText(string attackTipo)
    {
        criticText.text = attackTipo;
    }

    public void CombatWaveEnemiesInfo(int _wave, int _enemies)
    {
        cantEnemiesInWave.text = "Enemies in this wave "+ _enemies.ToString();
        cantWavesInRoom.text = "Waves in this Room " + _wave.ToString() ;
    }

}
