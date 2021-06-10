using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace enemyStatusConditions
{

    public class PlayerController : SingletonTemporal<PlayerController>
    {
        Character heroInstance;

        public int vida = 100;
        int vidaMax = 100;
        int attack;

        public int bonusMaxVida = 0;
        public int bonusAttack = 0;

        // Start is called before the first frame update
        void Start()
        {
            GenerateHeroInstance();
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
            //GenerateHeroInstance();
            heroInstance.hp = vida;
            //heroInstance.hp = heroInstance.maxHp;
            CombatManager.instance.dCPlayer.characterInstance = heroInstance;
            CombatManager.instance.dCPlayer.ActualiceDisplayData();

        }

        public void GetBonusHp(int value)
        {
            heroInstance.hp += value;
        }
        public void GetBonusMaxHp(int value)
        {
            bonusMaxVida += value;
            heroInstance.maxHp += value;
        }
        public void GetBonusAttack(int value)
        {
            bonusAttack += value;
            heroInstance.attack += value;
        }
        
    }
}