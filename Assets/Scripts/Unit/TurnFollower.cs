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

    bool stunned = false;
    public bool haveToWalk = true;

    void Awake()
    {
        
        currentNumberOfTurns = defaultNumberOfTurns;
        turnsBeforeStep = currentNumberOfTurns;
    }

    public void ActivateInp()
    {
        if(!stunned && haveToWalk)
        {
            turnsBeforeStep--;

            if (turnsBeforeStep - 1 == 0)
            {
                if (showAttacks != null)
                    showAttacks.ShowAttackPoints(bUnit.iinputs.PreTurn());


            }

            if (turnsBeforeStep == 0)
            {
                bUnit.canStep = true; //РАСКОМЕНТИТЬ ЕСЛИ ЧТО
                turnsBeforeStep = currentNumberOfTurns;
                //bUnit.StartWalk();
                if (showAttacks != null)
                    showAttacks.HideAttackPoints();
            }
        }    
           



       
        

    }

    public void ChangeNumberOfTurns(int newNumberOfTurns)
    {
        currentNumberOfTurns = newNumberOfTurns;
        turnsBeforeStep = currentNumberOfTurns;
        if(turnsBeforeStep-1 == 0)
        {
            if(showAttacks!=null)
                showAttacks.ShowAttackPoints(bUnit.iinputs.PreTurn());

            
        }
        else
            if(showAttacks!=null)
                showAttacks.HideAttackPoints();
    }
   
}
