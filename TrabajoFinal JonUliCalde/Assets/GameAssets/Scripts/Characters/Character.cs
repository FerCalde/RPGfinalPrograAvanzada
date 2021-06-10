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

        public GameObject imgPoison;
        public GameObject imgStun;

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
            //critChance = _crit;
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
                UpdateImages(imgPoison, true);
            }
            else
            {
                poisonedTurns = 0;
                maxPoisonedTurns = 0;
                UpdateImages(imgPoison, false);
            }

        }
        public void CheckIsStuned()
        {
            if (maxStunedTurns > stunedTurns)
            {
                stunedTurns++;
                isStuned = true;
                Debug.Log("Is stuneeddd");
                UpdateImages(imgStun, true);
            }
            else
            {
                isStuned = false;
                stunedTurns = 0;
                maxStunedTurns = 0;
                UpdateImages(imgStun, false);
            }
        }
        public void RegularAttack(int amount, Character targetToGo)
        {
            targetToGo.TakeDamage(amount);

            InfoManager.Instance.InfoChanger(name + " mete un meco que quita " + amount + " de vida");
        }
        public virtual void ChoseEnemyAction(int amount, Character targetToGo)
        {
        }
        public virtual void ChoseEnemyAction(int amount, Character targetToGo, int kindAttack)
        {

        }
        public void UpdateImages(GameObject img, bool active)
        {
            img.SetActive(active);
        }

    }
}

