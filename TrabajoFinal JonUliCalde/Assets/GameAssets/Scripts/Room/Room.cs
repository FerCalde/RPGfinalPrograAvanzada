using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Rooms
{
    public abstract class Room
    {
        public string roomName;
        public Text roomNameText;
        public bool hasEnemies;


        public Room(string _roomName, bool _hasEnemies)
        {
            roomName = _roomName;
            hasEnemies = _hasEnemies;
        }




        //public Room(string name)

        public void UpdateDisplayData()//Updates the name of the room 
        {
            //roomNameText.text = "Current room: " + roomName;
        }


        public virtual void ActivarRoom()
        {

        }
    }
}