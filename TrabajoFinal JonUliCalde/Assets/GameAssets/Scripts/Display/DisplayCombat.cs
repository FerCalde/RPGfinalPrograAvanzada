using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace enemyStatusConditions
{




    public class DisplayCombat : SingletonTemporal<DisplayCombat>
    {

        public GameObject panelSalas, panelCombat;
        bool switchPanels = false;

        [SerializeField] Button[] botonesAttackPlayer;

        // Start is called before the first frame update
        void Start()
        {

            SwitchPanels();
        }


        public void SwitchPanels( )
        {
            switchPanels = !switchPanels;

            panelSalas.SetActive(switchPanels);
            panelCombat.SetActive(!switchPanels);
        }

        public void ButtonsAttack()
        {
            //FALTARIA EL DO PLAYER ATTACK cuando pegue el pive
            //CombatController.instance.DoPlayerAttack();

            for (int i = 0; i < botonesAttackPlayer.Length; i++)
            {
                botonesAttackPlayer[i].interactable = false;
            }
        }

        public void EnableButtonsAttack()
        {
            for (int i = 0; i < botonesAttackPlayer.Length; i++)
            {
                botonesAttackPlayer[i].interactable = true;
            }
        }
    }
}