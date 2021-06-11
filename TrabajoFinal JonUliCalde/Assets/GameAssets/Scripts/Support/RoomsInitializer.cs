using enemyStatusConditions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;





namespace Rooms
{
    namespace enemyStatusConditions
    {
        public class RoomsInitializer : MonoBehaviour
        {
            int amountOfRooms = 10;
            int actualRoom = 1;
            GenericEnemiesQueue<Room>[] roomsArr;




            private void Start()
            {
                //InitRooms();
            }



            public void InitRooms() //Called from buttons.
            {
                roomsArr = new GenericEnemiesQueue<Room>[amountOfRooms];

                for (int i = 0; i < amountOfRooms; i++)
                {
                    //roomsArr[i] = new GenericEnemiesQueue<Room>();
                    int randomRoom = UnityEngine.Random.Range(0, 5);

                    if (randomRoom.Equals(0))
                    {
                        roomsArr[i] = new GenericEnemiesQueue<Room>();
                        ScRoomEnemies[] roomsData = Resources.LoadAll<ScRoomEnemies>("ScObjects/Rooms");
                        Room room = new RoomWithEnemies(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomEnemies);
                        roomsArr[i].PonerALaFila(room);



                    }

                    else if (randomRoom.Equals(1))
                    {
                        roomsArr[i] = new GenericEnemiesQueue<Room>();
                        ScRoomTrapMaxAttack[] roomsData = Resources.LoadAll<ScRoomTrapMaxAttack>("ScObjects/Rooms");
                        Room room = new RoomTrapAndMoreAttack(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomTrapMaxAttack);
                        roomsArr[i].PonerALaFila(room);
                    }

                    else if (randomRoom.Equals(2))
                    {
                        roomsArr[i] = new GenericEnemiesQueue<Room>();
                        ScRoomTrapMaxHp[] roomsData = Resources.LoadAll<ScRoomTrapMaxHp>("ScObjects/Rooms");
                        Room room = new RoomTrapAndMaxHealth(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomTrapMaxHp);
                        roomsArr[i].PonerALaFila(room);
                    }

                   /* else if (randomRoom.Equals(1))
                    {
                        roomsArr[i] = new GenericEnemiesQueue<Room>();
                        ScRoomTrap[] roomsData = Resources.LoadAll<ScRoomTrap>("ScObjects/Rooms");
                        //Room room = new RoomTrap(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomTrap);

                        var trapMaxAttack = roomsData.OfType<ScRoomTrapMaxAttack>();
                        var trapMaxHP = roomsData.OfType<ScRoomTrapMaxHp>();
                        
                        foreach (ScRoomTrapMaxAttack rData in trapMaxAttack)
                        {
                            Room room = new RoomTrapAndMoreAttack(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomTrapMaxAttack);
                             roomsArr[i].PonerALaFila(room);
                        }
                        foreach (ScRoomTrapMaxHp rData in trapMaxHP)
                        {
                            Room room = new RoomTrapAndMaxHealth(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomTrapMaxHp);
                            roomsArr[i].PonerALaFila(room);
                        }
                       
                    }*/

                    else if (randomRoom.Equals(3))
                    {
                        roomsArr[i] = new GenericEnemiesQueue<Room>();
                        ScRoomHealMaxHp[] roomsData = Resources.LoadAll<ScRoomHealMaxHp>("ScObjects/Rooms");
                        Room room = new RoomRestoreHealthAndMaxHealth(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomHealMaxHp);
                        roomsArr[i].PonerALaFila(room);
                    }

                    else if (randomRoom.Equals(4))
                    {
                        roomsArr[i] = new GenericEnemiesQueue<Room>();
                        ScRoomHealEnemies[] roomsData = Resources.LoadAll<ScRoomHealEnemies>("ScObjects/Rooms");
                        Room room = new RoomRestoreHealthAndEnterEnemies(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomHealEnemies);
                        roomsArr[i].PonerALaFila(room);
                    }

                    /*else if (randomRoom.Equals(2))
                    {
<<<<<<< Updated upstream
                        roomsArr[i] = new GenericEnemiesQueue<Room>();
                        ScRoomHeal[] roomsData = Resources.LoadAll<ScRoomHeal>("ScObjects/Rooms");
                        Room room = new RoomRestoreHealth(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomHeal);
                        roomsArr[i].PonerALaFila(room);



                    }
=======
                        
                        roomsArr[i] = new GenericEnemiesQueue<Room>();
                        ScRoomHeal[] roomsData = Resources.LoadAll<ScRoomHeal>("ScObjects/Rooms");
                        //Room room = new RoomRestoreHealth(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomHeal);
                        //if (roomsData[i])

                        var healAndEnemies = roomsData.OfType<ScRoomHealEnemies>();
                        var healMaxHP = roomsData.OfType<ScRoomHealMaxHp>();
                        
                        foreach (ScRoomHealEnemies rData in healAndEnemies)
                        {
                            Room room = new RoomRestoreHealthAndEnterEnemies(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomHealEnemies);
                            roomsArr[i].PonerALaFila(room);
                        }
                        foreach (ScRoomHealMaxHp rData in healMaxHP)
                        {
                            Room room = new RoomRestoreHealthAndMaxHealth(roomsData[UnityEngine.Random.Range(0, roomsData.Length)] as ScRoomHealMaxHp);
                            roomsArr[i].PonerALaFila(room);
                        }
                        
                    }
>>>>>>> Stashed changes*/




                    

                    
                }
                MakeNextRoomAppear();
            }


            public void MakeNextRoomAppear()
            {
                StartCoroutine(NextRoom());
            }

            IEnumerator NextRoom()
            {
                yield return new WaitForSeconds(0.5f);
                //check current room

                

                if (roomsArr[actualRoom - 1].count > 0)
                {
                    RoomManager.Instance.room = roomsArr[actualRoom - 1].QuitarDeLaFila();
                    //ProgresManager.Instance.UpdateCurrentRooms();
                    RoomManager.Instance.DisplayRoomName();
                    RoomManager.Instance.room.ActivarRoom();
                    /*if (RoomManager.Instance.room.hasEnemies)
                    {
                        //RoomManager.Instance.room.
                        GameController.instance.EmpezarCombateRoom();
                        //CombatManager.Instance
                        Debug.Log("Enemies room");
                        //RoomManager.Instance.room.UpdateDisplayData();
                    }*/
                    /*else
                    {
                        Debug.Log("No enemies");
                    }*/



                }
                else
                {
                    actualRoom++;
                    if (roomsArr.Length >= actualRoom)
                    {
                        RoomManager.Instance.room = roomsArr[actualRoom - 1].QuitarDeLaFila();
                        RoomManager.Instance.room.UpdateDisplayData();
                        actualRoom++;
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
    
}



