using System.Collections;
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


        [SerializeField] Image hp;
        [SerializeField] float critico;

        public void ActualiceDisplayData()
        {
            nameTxt.text = characterInstance.name.ToString();
            attackTxt.text = characterInstance.attack.ToString();


            critico = characterInstance.critChance;
            ActualiceHp(characterInstance.hp);
        }

        public void ActualiceHp(int value)
        {
            float width = (value * 100) / characterInstance.maxHp;
            //hp.rectTransform.sizeDelta = new Vector2(width, hp.rectTransform.sizeDelta.y);
            hp.fillAmount = width;
        }
    }
}