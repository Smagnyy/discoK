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
    public int defaultNumberOfTurns =3; 
    public int currentNumberOfTurns;   
    public int turnsBeforeStep;
    void Awake()
    {
        
        currentNumberOfTurns = defaultNumberOfTurns;
        turnsBeforeStep = currentNumberOfTurns;
    }

    public void ActivateInp()
    {
        turnsBeforeStep--;

        if(turnsBeforeStep==0)
        {
            bUnit.canStep = true;
            turnsBeforeStep = currentNumberOfTurns;
            if(showAttacks!=null)
                showAttacks.HideAttackPoints();
        }

        if(turnsBeforeStep-1 == 0)
        {
            if(showAttacks!=null)
                showAttacks.ShowAttackPoints(bUnit.iinputs.PreTurn());
        }

    }
   
}
