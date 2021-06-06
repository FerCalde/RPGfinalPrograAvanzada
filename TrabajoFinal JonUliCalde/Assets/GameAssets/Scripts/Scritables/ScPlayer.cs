using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player/new Player", order = 1)]
public class ScPlayer : ScriptableObject
{
    public string _playerName;
    public int _attack;
    public float _crit;
    public bool _hasPoisonAttack;
    public bool _hasStunAttack;
    public bool _hasRestAttack;
    public bool _hasNormalAttack;
}
