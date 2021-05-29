using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelController : MonoBehaviour
{
    #region singleton
    public static ActionPanelController instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] Button attackButton;
    [SerializeField] Text infoTxt;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject characterPanel;
    bool switchPanels = false;

    public void EnableAttackButton() {
        attackButton.interactable = true;
    }

    public void AttackButon() {
        if (CombatController.instance.enemyDisplay.characterInstance != null)
        {
            CombatController.instance.DoPlayerAttack();
            attackButton.interactable = false;
        }
    }

    public void ShowInventorySwitch() {
        switchPanels = !switchPanels;

        inventoryPanel.SetActive(switchPanels);
        characterPanel.SetActive(switchPanels);
    }

    public void DisplayInfo(string info) {
        infoTxt.text = info;
    }
    
}
