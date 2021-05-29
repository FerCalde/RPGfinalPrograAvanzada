using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Character/Hero/new Hero", order = 0)]
public class ScHero : ScriptableObject
{
    public string _heroName;
    public int _attack;
    public int _defense;
    public float _crit;
    public Sprite _faceImg;
    public Sprite _modelImg;
}
