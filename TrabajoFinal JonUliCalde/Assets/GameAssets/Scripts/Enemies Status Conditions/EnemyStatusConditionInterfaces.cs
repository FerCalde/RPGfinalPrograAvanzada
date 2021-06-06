using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace enemyStatusConditions
{

    public interface IStun
    {
        void GetStuned(int turns); //This function can affect either the enemy or the player.
    }

    public interface IPoison
    {
        void GetPoisoned(int turns); //This function can affect either the enemy or the player.
    }

    public interface IRegularAttack
    {
        void TakeDamage(int amount);
    }

    public interface IRest
    {
        void GetRest(int amount);
    }

}

    
