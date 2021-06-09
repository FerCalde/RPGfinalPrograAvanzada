using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{

    public interface IEnemiesRoom
    {
        void EnterEnemyRoom();
    }

    public interface IChangePlayerHealth
    {
        void UpdatePlayerHealth();
    }
    
    public interface IPlayerCanDealMoreDamage
    {
        void PlayerDealMoreDamage();
    }

    public interface IPlayerMaxHealthIncreases
    {
        void IncreasePlayerMaxHealth();
    }

    


    


}




