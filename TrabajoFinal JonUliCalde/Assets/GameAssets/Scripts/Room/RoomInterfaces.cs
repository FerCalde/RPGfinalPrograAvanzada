using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public interface ICanEnter
    {
        bool CanEnter();

    }

    public interface IRandomizeHealOrDamageRoom
    {
        void RandomizeHealOrDamageRoom();
    }

    public interface IGenerateRandomItems
    {
        void GenerateRandomItems(int amountOfItems); //Generates 2 random items after receiving the key.
    }

    public interface IRecoverHealth
    {
        void RecoverHealth();
    }

    public interface IHasTakenKey
    {
        bool HasTakenKey(); //Checks if current room's key has already been taken.
    }
}
   



