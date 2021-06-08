using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace enemyStatusConditions
{
    public class RoomsInitializer : MonoBehaviour
    {
        int amountOfRooms = 10;
        int actualRoom = 1;
        GenericEnemiesQueue<Room>[] roomsArr;




        void InitRooms()
        {
            roomsArr = new GenericEnemiesQueue<Room>[amountOfRooms];
            for (int i = 0; i < amountOfRooms; i++)
            {
                roomsArr[i] = new GenericEnemiesQueue<Room>();
                //  object[] objectsData = Resources.LoadAll("ScObjects/Rooms", typeof(ScRoom)); //Change Route

                /*for (int j = 0; j < enemiesPerWave; j++)
                {
                    Room room = new Room(roomsData[UnityEngine.Random.Range(0, room.Length)] as ScRoom);
                    //enemy.hp = enemy.maxHp;
                    roomsArr[i].PonerALaFila(room);
                }*/
            }
        }


        public void MakeNextRoomAppear()
        {
            StartCoroutine(NextRoom());
        }

        IEnumerator NextRoom()
        {
            yield return new WaitForSeconds(3);

            if (roomsArr[actualRoom - 1].count > 0)
            {
                RoomManager.Instance.room = roomsArr[actualRoom - 1].QuitarDeLaFila();
                RoomManager.Instance.room.UpdateDisplayData();

                


            }
            else
            {
                actualRoom++;
                if (roomsArr.Length >= actualRoom)
                {
                    RoomManager.Instance.room = roomsArr[actualRoom - 1].QuitarDeLaFila();
                    RoomManager.Instance.room.UpdateDisplayData();
                }
                else
                {
                    //END GAME
                    //RoomManager.Instance.room.EndGame();

                }
            }
        }
    }

}
