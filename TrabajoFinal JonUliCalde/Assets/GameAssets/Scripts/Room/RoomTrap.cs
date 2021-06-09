using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public class RoomTrap : Room, IChangePlayerHealth
    {
        int _healthModification; //It can be adding or substracting health.

        public virtual int healthModification
        {
            get { return _healthModification; }
            set
            {
                _healthModification = Mathf.Clamp(value,-100, 0);
            }
        }

        public RoomTrap(ScRoomTrap data): base(data._roomName, data._enemies)
        {
            _healthModification = data.damageTrampa;
        }

        

        public virtual void UpdatePlayerHealth()
        {
            //display

            //_healthModification = CombatController.instance.heroDisplay.characterInstance.hp -= _healthModification;
            Debug.Log("Player receives damage: " + _healthModification);
        }

  



    }
}

