﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace enemyStatusConditions
{

    public class DisplayCharacter : MonoBehaviour
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
                else
                {
                    value.OnHpChange -= ActualiceHp;
                }

            }
        }

        [SerializeField] Text nameTxt;
        [SerializeField] Text attackTxt;
        [SerializeField] Text vidaHp;

        [SerializeField] Image hp;
        [SerializeField] float critico;

        [SerializeField] GameObject venom;
        [SerializeField] GameObject stun;

        public void ActualiceDisplayData()
        {
            nameTxt.text = "Nombre: " + characterInstance.name.ToString();
            attackTxt.text = "Ataque: " + characterInstance.attack.ToString();

            vidaHp.text = "Vida: " + characterInstance.hp;
            //critico = characterInstance.critChance;
            ActualiceHp(characterInstance.hp);
            _character.imgPoison = venom;
            _character.imgStun = stun;
        }

        public void ActualiceHp(int value)
        {
            //print(value + " ES la vida");

            float width = (float)(value * 360) / (float)characterInstance._maxHp;
            hp.rectTransform.sizeDelta = new Vector2((float)width, hp.rectTransform.sizeDelta.y);
            vidaHp.text = "Vida: " + characterInstance.hp;
            //hp.fillAmount = width;
        }




    }
}