using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicEnemy", menuName = "Characters/Enemy/new BasicEnemy", order = 1)]
public class ScEnemy : ScriptableObject
{
    public string _enemyName;
    public int _attack;
    public float _crit;
}
