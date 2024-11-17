using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsEnemy : MonoBehaviour, Iinputs
{
    Vector2[] directions = new Vector2[4] {new Vector2(0,1),new Vector2(0,-1),new Vector2(1,0),new Vector2(-1,0)};

    //float timeBtwMoves = 1.5f;

    //float timer = 1.5f;

    bool canStep = false;

    private void Awake() 
    {
        TurnManager.Turn += CanStep;
    }

    public Vector2 Inp()
    {
         

        if(canStep)
        {
            canStep = false;
            Debug.Log("new turn");
            return Turn();
            
           
        }

        return Vector2.zero;
    }

    public void CanStep()
    {
        canStep = true;
    }

    /*
    public void EditTimer(float _counter)
    {
        timer = _counter;
    }*/

    Vector2 Turn()
    {
        int i = Random.Range(0, directions.Length);

        return directions[i];
    }
   
}
