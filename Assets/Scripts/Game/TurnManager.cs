using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
   // int turnsBeforeEnemyTurn = 3;
   // int defaultTurns =3;
    public static event Action Turn; 
    
    

    private void Awake() 
    {
        InputsPlayer.Counter +=StartEnemy;
    }

    void StartEnemy()
    {
        //Turn?.Invoke();
        //StartCoroutine(CountTurns());

        StartCoroutine(DelayBeforeTurn());
    }

    //public IEnumerator CountTurns()
    //{
    //    turnsBeforeEnemyTurn--;
//
    //    if(turnsBeforeEnemyTurn<1)
    //    {
    //        yield return new WaitForSeconds(0.05f);
    //        Turn?.Invoke();
    //        turnsBeforeEnemyTurn = defaultTurns;
    //    }
    //     UI_main.Instance.UpdatePossibleStepsText(turnsBeforeEnemyTurn);
    //}

    IEnumerator DelayBeforeTurn()
    {
        yield return new WaitForSeconds(0.05f);
        Turn?.Invoke();
        yield break;
    }
}
