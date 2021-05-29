using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Character/Enemy/new Enemy", order =1)]
public class ScEnemy : ScriptableObject
{
    public string _EnemyName;
    public int _attack;
    public int _defense;
    public float _crit;
    public Sprite _faceImg;
    public Sprite _modelImg;
}
