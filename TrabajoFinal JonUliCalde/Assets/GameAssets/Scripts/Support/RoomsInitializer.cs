using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsInitializer : MonoBehaviour
{
    int amountOfRooms = 10;
    GenericEnemiesQueue<Room>[] roomsArr;


    void InitRooms()
    {
        roomsArr = new GenericEnemiesQueue<Room>[amountOfRooms];
        for (int i = 0; i < amountOfRooms; i++)
        {
            roomsArr[i] = new GenericEnemiesQueue<Room>();
            object[] objectsData = Resources.LoadAll("ScObjects/Rooms", typeof(ScEnemy)); //Change Route

            /*for (int j = 0; j < enemiesPerWave; j++)
            {
                Room room = new Room(enemiesData[UnityEngine.Random.Range(0, enemiesData.Length)] as ScEnemy);
                //enemy.hp = enemy.maxHp;
                roomsArr[i].PonerALaFila(enemy);
            }*/
        }
    }

}
