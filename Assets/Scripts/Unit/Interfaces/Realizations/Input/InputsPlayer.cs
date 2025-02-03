using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsPlayer : MonoBehaviour, Iinputs
{
    public GameObject spriteGameObj;

   
    
    //int possibleSteps;
    // [SerializeField]
    //int maxPossibleSteps = 3;

    private void Awake() 
    {
       // EnemySpawner.OnTimerUpdated += UpdatePossibleSteps;
        //possibleSteps = maxPossibleSteps;
    }

   // void UpdatePossibleSteps()
   // {
   //     possibleSteps = maxPossibleSteps;
   //     UI_main.Instance.UpdatePossibleStepsText(possibleSteps);
   // }

    Coroutine shakeCoroutine;

    public Vector2 Inp()
    {   
        if(GlobalValues.IsPlayerAlive)
        {

        
        //Debug.Log("в корутине это" + shakeCoroutine);   
        Vector2 dir = Vector2.zero;
       
            //shakeCoroutine = null;
            if (Input.GetKey(KeyCode.W))        
                dir = new Vector2(0, 1);
          
            else if (Input.GetKey(KeyCode.S))        
                dir = new Vector2(0, -1);
           
            else if (Input.GetKey(KeyCode.A)) 
                dir = new Vector2(-1, 0);

            else if (Input.GetKey(KeyCode.D)) 
                dir = new Vector2(1, 0);

       
      

        
        if( dir != Vector2.zero) //possibleSteps > 0 &&
        {   
            TurnManager.Instance.Turn();
            return dir;
            //possibleSteps--;
            //UI_main.Instance.UpdatePossibleStepsText(possibleSteps);
            
        }
       // else if(possibleSteps <= 0 && dir != Vector2.zero)
       // {
       //     if(shakeCoroutine!=null)
       //     {
       //         StopCoroutine(shakeCoroutine);
       //         shakeCoroutine = null;
       //     }
       //     //shakeCoroutine = StartCoroutine(Effects.Shake(5, spriteGameObj));
       //     shakeCoroutine = StartCoroutine(Effects.ShakeSin(spriteGameObj, 2, 0.05f, 3.2f));
       //      Debug.Log("SHAKE");
       //     return Vector2.zero;
       // }      

        
        }    
        return Vector2.zero;
    }

    public List<Vector2> PreTurn()
    {
        throw new NotImplementedException();
    }
}
