using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventarios
{
    public interface ISelleable
    {
        void Sell(int amount);
    }
    public interface IEquipable
    {
        void Equip(EquipSlot slot);
    }
    public interface IDurable
    {
        void LoseDurability(int amount);
        void Repair();
    }
    public interface IUsable
    {
        void Consume();
    }
    public interface IDoorInteractive
    {

    }
    
}

