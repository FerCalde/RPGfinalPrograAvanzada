using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public abstract class RoomRestoreHealthOrDealDamage : Room, IRecoverHealth, IRandomizeHealOrDamageRoom
    {
        int _healthToRestore;

        public int healthToRestore
        {
            get { return _healthToRestore; }
            set
            {
                _healthToRestore = Mathf.Clamp(value, 0, 100);
            }
        }

        public void RandomizeHealOrDamageRoom()
        {
            int healOrDamage = Random.Range(0, 1);

            if (healOrDamage.Equals(0))
            {

            }


        }

        public void RecoverHealth()
        {
            _healthToRestore = CombatController.instance.heroDisplay.characterInstance.hp += healthToRestore;
            Debug.Log("Player recovers " + healthToRestore);
        }



    }
}

