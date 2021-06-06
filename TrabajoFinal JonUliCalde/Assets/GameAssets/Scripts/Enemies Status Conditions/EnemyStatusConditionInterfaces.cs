using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace enemyStatusConditions
{

    public interface IStun
    {
        void Stun(GameObject targetGO); //This function can affect either the enemy or the player.
    }

    public interface IPoison
    {
        void Poison(GameObject targetGO); //This function can affect either the enemy or the player.
    }

}

    
