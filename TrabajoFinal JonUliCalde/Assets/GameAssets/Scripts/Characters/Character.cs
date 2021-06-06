using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public delegate void HpDelegate(int hp);
    public event HpDelegate OnHpChange;

    public int maxHp = 100;
    public string name;
    public int attack;
    public float critChance;
    public bool hasPoison;
    public bool hasStun;
    public bool hasRest;
    public bool hasNormalAttack;

    public int poisonedTurns = 0;
    public int maxPoisonedTurns = 0;
    public int stunedTurns = 0;
    public int maxStunedTurns = 0;

    private int _hp;

    public int hp
    {
        get { return _hp; }
        set
        {
            _hp = Mathf.Clamp(value, 0, maxHp);
            OnHpChange?.Invoke(_hp);
        }
    }

    public Character(string _name, int _atk, float _crit, bool _hasPoi, bool _hasStun, bool _hasRest, bool _hasNA)
    {
        name = _name;
        attack = _atk;
        critChance = _crit;
        hasPoison = _hasPoi;
        hasStun = _hasStun;
        hasRest = _hasRest;
        hasNormalAttack = _hasNA;
    }

    public virtual void TakeDamage(int amount)
    {
        hp -= amount;
    }
    public virtual void getRest(int amount)
    {
        hp += amount;
    }
    public virtual void CheckIsPoisoned(int amount)
    {
        if (maxPoisonedTurns > poisonedTurns)
        {
            TakeDamage(amount);
            poisonedTurns++;
        }
        else
        {
            poisonedTurns = 0;
        }

    }
    public virtual void GetPoisoned (int turns)
    {
        maxPoisonedTurns = turns;
    }
    public virtual void CheckIsStuned()
    {
        if ( maxStunedTurns > stunedTurns)
        {
            stunedTurns++;
        }
        else
        {
            stunedTurns = 0;
        }
    }
}
