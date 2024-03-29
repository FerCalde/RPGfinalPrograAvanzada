﻿using enemyStatusConditions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Rooms
{

    public class RoomWithEnemies : Room, IEnemiesRoom
    {


        public RoomWithEnemies(ScRoomEnemies data) : base(data._roomName, data._enemies)
        {

        }

        public void EnterEnemyRoom()
        {
            GameController.instance.EmpezarCombateRoom();

        }

        public override void ActivarRoom()
        {
            EnterEnemyRoom();
            InfoManager.Instance.InfoChanger("Aparecieron enemigos");
        }

    }


}

