using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventarios
{
    public class ItemButton : MonoBehaviour
    {
        [HideInInspector]
        public Item item;

        //Referencias UI
        [SerializeField]
        private Image iconImg;
        [SerializeField]
        private Text costTxt;

        private void Start()
        {
            iconImg.sprite = item.image;
            costTxt.text = item.cost.ToString();
        }

        public void LeftPressButton()
        {
            item.PrimaryUse();
            Destroy(this.gameObject);
        }
        public void RightPressButton()
        {
            item.SecondaryUse();
            Destroy(this.gameObject);
        }

    }
}


