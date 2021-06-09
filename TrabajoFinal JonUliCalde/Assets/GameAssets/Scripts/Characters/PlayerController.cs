using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace enemyStatusConditions
{

    public class PlayerController : MonoBehaviour
    {
        Character heroInstance;

        int vida = 100;
        int vidaMax = 100;
        int attack;

        int bonusVida = 0;
        int bonusMaxVida = 0;
        int bonusAttack = 0;

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
            attack = heroInstance.attack;
        }


        void SetPlayerInCharDisplay(object sender, StartGameArgs e)
        {
            GenerateHeroInstance();
            CheckBonus();
            //heroInstance.hp = heroInstance.maxHp;
            CombatManager.instance.dCPlayer.characterInstance = heroInstance;
            CombatManager.instance.dCPlayer.ActualiceDisplayData();
        }

        public void GetBonusHp()
        {
            bonusVida++;
        }
        public void GetBonusMaxHp()
        {
            bonusMaxVida++;
        }
        public void GetBonusAttack()
        {
            bonusAttack++;
        }
        public void CheckBonus()
        {
            heroInstance.maxHp = heroInstance.maxHp + (bonusMaxVida*10);
            heroInstance.hp = heroInstance.hp + (bonusVida * 10);
            heroInstance.attack = attack + (bonusAttack * 10);
        }
    }
}