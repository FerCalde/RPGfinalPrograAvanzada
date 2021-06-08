using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace enemyStatusConditions
{

    public interface IStun
    {
        void StunAttack(int turns, Character targetToGo); //This function can affect either the enemy or the player.
    }

    public interface IPoison
    {
        void PoisonAttack(int turns, Character targetToGo); //This function can affect either the enemy or the player.
    }

    public interface IRegularAttack
    {
        void RegularAttack(int amount, Character targetToGo);
    }

    public interface IRest
    {
        void GetRest(int amount);
    }
    public interface IThisisanEnemy
    {

    }

}

    
