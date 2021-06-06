using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy/new Enemy", order = 0)]
public class ScEnemy : ScriptableObject
{
    public string _enemyName;
    public int _attack;
    public float _crit;
    public bool _hasPoisonAttack;
    public bool _hasStunAttack;
    public bool _hasRestAttack;
    public bool _hasNormalAttack;
}
