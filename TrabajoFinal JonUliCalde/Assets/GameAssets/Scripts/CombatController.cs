using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    #region singleton
    public static CombatController instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public enum CombatTurns { PLAYERTURN, ENEMYTURN, GAMEOVER }
    public CombatTurns combatTurn = CombatTurns.PLAYERTURN;
    [SerializeField] float turnTime;

    //Crear un delegado con la misma signatura que los tipos de ataques 
    public delegate void DelegateAttack(int basicDamage, float critChance, ref int total);
    DelegateAttack attackDelegate;
    //Variable de daño de ataque total
    int totalDamage;


    public delegate void NextTurn();
    public event NextTurn OnNextTurn;

    string displayResult;
    public CharacterDisplay enemyDisplay;
    public CharacterDisplay heroDisplay;

    private void Start()
    {
        OnNextTurn += CombatSecuence;

        //Añadir los métodos de los ataques al delegado multicast
        attackDelegate = new DelegateAttack(BasicHit);
        attackDelegate += CriticalHit;
        attackDelegate += MissChance;
    }

    //basic hit
    void BasicHit(int basicDamage, float critChance, ref int total)
    {
        //Random entre la mitad del damage que puede hacer y su propio damage como maximo
        int damageRandom = Mathf.RoundToInt(Random.Range(basicDamage - 3, basicDamage));
        total = damageRandom;
        displayResult = total.ToString() + "  Hit!";
    }
    //Critical
    void CriticalHit(int basicDamage, float critChance, ref int total)
    {

        float randomNum = Random.Range(0, 100);
        if (randomNum <= critChance)
        {
            //total = basicDamage;
           // Debug.Log("Critic! " + randomNum);
            total = total * 2;
           // displayResult = total.ToString() + "  Hit!";
            Debug.Log(total.ToString());
        }
    }
    //miss
    void MissChance(int basicDamage, float critChance, ref int total)
    {

        //total = basicDamage;
        float randomNum = Random.Range(0, 100);
        if (randomNum < critChance)
        {
            Debug.Log("FAIL! " + randomNum);
            total = 0;
            //displayResult = //attacker.characerName.ToString() + " hits " + fullDamage.ToString();
            //displayResult = " has Fail the Hit!";
        }
    }

    void CalculateAttackDamage(Character attacker)
    {
        //Inicializar variable de daño total
        totalDamage = 0;
        //Llamada al delegado de ataque
        attackDelegate.Invoke(attacker.attak, attacker.critChance, ref totalDamage);

    }

    IEnumerator DoCombat(Character attacker, Character defender)
    {

        //Calcular el daño total que hace el atacante aplicando el multicast por referencia
        CalculateAttackDamage(attacker);

        //Aplicar el daño total (daño de ataque - la defensa) al defensor

        int fullDamage = totalDamage - defender.defense;
        if (fullDamage <= 0)
        {
            fullDamage = 0;
            displayResult = attacker.characerName + " Fail the Hit";
        }
        
        if (fullDamage > 0)
        {
            if (attacker.attak < totalDamage)
            {
                displayResult = attacker.characerName + " Critical Hit " + fullDamage.ToString();
            }
            else
            {
                displayResult = attacker.characerName + " Hit " + fullDamage.ToString();
            }

        }

        defender.TakeDamage(fullDamage);

        //print(fullDamage + " " + attacker.characerName);

        //Mostrar los resultados visualmente usando el método DisplayResults
        DisplayResults();

        yield return new WaitForSeconds(turnTime);
        OnNextTurn?.Invoke();
    }

    void DisplayResults()
    {//Modificar este método para conseguir que se muestren los resultados en el display

        ActionPanelController.instance.DisplayInfo(displayResult);

    }

    void CombatSecuence()
    {
        switch (combatTurn)
        {
            case CombatTurns.PLAYERTURN:
                combatTurn = CombatTurns.ENEMYTURN;
                StartCombat(enemyDisplay.characterInstance, heroDisplay.characterInstance);
                break;
            case CombatTurns.ENEMYTURN:
                combatTurn = CombatTurns.PLAYERTURN;
                ActionPanelController.instance.DisplayInfo("Player turn");
                ActionPanelController.instance.EnableAttackButton();
                break;
            case CombatTurns.GAMEOVER:
                ActionPanelController.instance.DisplayInfo("Game Over");
                break;
        }
    }

    public void DoPlayerAttack()
    {
        StartCombat(heroDisplay.characterInstance, enemyDisplay.characterInstance);
    }

    void StartCombat(Character attacker, Character defender)
    {
        StartCoroutine(DoCombat(attacker, defender));
    }
}
