using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Inventarios;
using System;

public class CharacterDisplay : MonoBehaviour
{
    Character _character;
    [HideInInspector]
    public Character characterInstance
    {
        get { return _character; }
        set
        {

            //Suscribir y dar de baja del método ActualiceHp al character

            if (value != null)
            {
                value.OnHpChange += ActualiceHp;
                _character = value;
            }
            else if(value==null)
            {
                value.OnHpChange -= ActualiceHp;
            }

        }
    }

    [SerializeField] Text nameTxt;
    [SerializeField] Text attackTxt;
    [SerializeField] Text defenseTxt;
    [SerializeField] Image face;
    [SerializeField] Image characterModel;
    [SerializeField] Image hp;
    [SerializeField] float critico;
    
    public void ActualiceDisplayData()
    {
        nameTxt.text = characterInstance.characerName.ToString();
        attackTxt.text = characterInstance.attak.ToString();
        defenseTxt.text = characterInstance.defense.ToString();
        face.sprite = characterInstance.face;
        characterModel.sprite = characterInstance.model;
        critico = characterInstance.critChance;
        ActualiceHp(characterInstance.hp);
    }

    public void ActualiceHp(int value)
    {
        float width = (value * 100) / characterInstance.maxHp;
        hp.rectTransform.sizeDelta = new Vector2(width, hp.rectTransform.sizeDelta.y);
        
    }


}
