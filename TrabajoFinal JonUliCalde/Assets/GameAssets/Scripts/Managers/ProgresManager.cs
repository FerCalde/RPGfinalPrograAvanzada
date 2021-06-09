using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresManager : SingletonTemporal<ProgresManager>
{
    [SerializeField] Text enemiesKill;
    [SerializeField] Text currentRooms;
    int Enemies = 0;
    int Rooms = 0;
    public void UpdateCurrentEnemiesKilled()
    {
        Enemies++;
        enemiesKill.text = "EnemigosMatados: " + Enemies.ToString();
    }
    public void UpdateCurrentRooms()
    {
        Rooms++;
        currentRooms.text = "Salas recorridas: " + Rooms.ToString();
    }

}
