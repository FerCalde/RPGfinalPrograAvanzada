using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player/new Player", order = 0)]
public class ScPlayer : ScriptableObject
{
    public string _playerName;
    public int _attack;
    public float _crit;
}
