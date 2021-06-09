using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Rooms
{
    public class RoomManager : SingletonTemporal<RoomManager>
    {
        [SerializeField] Text roomName;


        public Room room;



    }

}
