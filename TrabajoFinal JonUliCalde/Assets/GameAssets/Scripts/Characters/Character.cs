using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace enemyStatusConditions
{
    public abstract class Character : EnemyStatusCondition, IRegularAttack
    {
        public delegate void HpDelegate(int hp);
        public event HpDelegate OnHpChange;

        public int maxHp = 100;
        public string name;
        public int attack;
        public float critChance;
        public int poisonedTurns = 0;
        public int maxPoisonedTurns = 0;
        public int stunedTurns = 0;
        public int maxStunedTurns = 0;

        public bool isStuned = false;

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

        public Character(string _name, int _atk, float _crit)
        {
            name = _name;
            attack = _atk;
            critChance = _crit;
        }

        public virtual void TakeDamage(int amount)
        {
            hp -= amount;
        }

        public void CheckIsPoisoned(int amount)
        {
            if (maxPoisonedTurns > poisonedTurns)
            {
                TakeDamage(amount);
                poisonedTurns++;
                
            }
            else
            {
                
                poisonedTurns = 0;
                maxPoisonedTurns = 0;
            }

        }
        public void CheckIsStuned()
        {
            if (maxStunedTurns > stunedTurns)
            {
                stunedTurns++;
                isStuned = true;
                Debug.Log("Is stuneeddd");
            }
            else
            {
                isStuned = false;
                stunedTurns = 0;
                maxStunedTurns = 0;
            }
        }
        public void RegularAttack(int amount, Character targetToGo)
        {
            targetToGo.TakeDamage(amount);

            InfoManager.Instance.InfoChanger(name + " te mete un meco de " + amount);
        }
        public virtual void ChoseEnemyAction(int amount, Character targetToGo)
        {
        }
        public virtual void ChoseEnemyAction(int amount, Character targetToGo, int kindAttack)
        {

        }

    }
}

