using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character
{
    //Crear un delegado con un parámetro int para controlar la vida
    public delegate void SendHp(int current_hp); 
    
    //Crear un evento "OnHpChange" e invocarlo en la propiedad hp
    public event SendHp OnHpChange; 
    
    void metodo1(int hp) { }
        

    public int maxHp = 100;
    public string characerName;
    public int attak;
    public int defense;
    public float critChance;
    public Sprite face;
    public Sprite model;

    private int _hp;
    public int hp {
        get { return _hp; }
        set {
            _hp = Mathf.Clamp(value, 0, maxHp);
            OnHpChange?.Invoke(_hp);
            if (_hp <= 0)
            {
                Debug.Log("Is dead!");
            }
            //ControlHp = new SendHp();
        }
    }
    

    public Character(string _chName, int _atk, int _def,float _crit, Sprite _face, Sprite _model)
    {
        characerName = _chName;
        attak = _atk;
        defense = _def;
        critChance = _crit;
        hp = maxHp;
        face = _face;
        model = _model;
    }

    public virtual void TakeDamage(int ammount)
    {
        hp -= ammount;
       
    }

    

}
