using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace enemyStatusConditions
{

    public class PlayerController : MonoBehaviour
    {
        Character heroInstance;

        // Start is called before the first frame update
        void Start()
        {
            //GenerateHeroInstance();
            GameController.instance.OnCombatStart += SetPlayerInCharDisplay;
        }

        public void GenerateHeroInstance()
        {
            object heroData;
            heroData = Resources.Load("ScObjects/Personajes/Player");
            heroInstance = new Player(heroData as ScPlayer);
        }


        void SetPlayerInCharDisplay(object sender, StartGameArgs e)
        {
            GenerateHeroInstance();
            heroInstance.hp = heroInstance.maxHp;
            CombatManager.instance.dCPlayer.characterInstance = heroInstance;
            CombatManager.instance.dCPlayer.ActualiceDisplayData();
        }


    }
}