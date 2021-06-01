using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public abstract class RoomRestoreHealthOrDealDamage : Room, IRecoverHealth, IRandomizeHealOrDamageRoom
    {
        int _healthModification; //It can be adding or substracting health.

        public int healthModification
        {
            get { return _healthModification; }
            set
            {
                _healthModification = Mathf.Clamp(value, 0, 100);
            }
        }

        public void RandomizeHealOrDamageRoom() //Here we randomize the type of room, if it is recover or damage room. We also call the correspondent function for that functionality.
        {
            int healOrDamage = Random.Range(0, 2); //50% chance.

            if (healOrDamage.Equals(0))
            {
                RecoverHealth(); 
            }
            else
            {
                DealDamage();
            }


        }

        public void RecoverHealth()
        {
            //_healthModification = CombatController.instance.heroDisplay.characterInstance.hp += _healthModification;
            Debug.Log("Player recovers: " + _healthModification);
        }

        public void DealDamage()
        {
            //_healthModification = CombatController.instance.heroDisplay.characterInstance.hp -= _healthModification;
            Debug.Log("Player receives damage: " + _healthModification);
        }



    }
}

