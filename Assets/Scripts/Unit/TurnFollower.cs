using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFollower : MonoBehaviour
{
    [SerializeField]
    BaseUnit bUnit;
    [SerializeField]
    ShowAttacks showAttacks;
    
    [SerializeField]
    int defaultTurns =3;    
    int turnsBeforeEnemyTurn;
    void Awake()
    {
        TurnManager.Turn += ActivateInp;
        turnsBeforeEnemyTurn = defaultTurns;
    }

    void ActivateInp()
    {
        turnsBeforeEnemyTurn--;

        if(turnsBeforeEnemyTurn<1)
        {
            bUnit.canStep = true;
            turnsBeforeEnemyTurn = defaultTurns;
            if(showAttacks!=null)
                showAttacks.HideAttackPoints();
        }

        if(turnsBeforeEnemyTurn-1 == 0)
        {
            if(showAttacks!=null)
                showAttacks.ShowAttackPoints(bUnit.iinputs.PreTurn());
        }

    }
   
}
