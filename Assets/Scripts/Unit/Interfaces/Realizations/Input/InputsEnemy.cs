using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsEnemy : MonoBehaviour, Iinputs
{
    List<Vector2> directions = new List<Vector2>{new Vector2(0,1),new Vector2(0,-1),new Vector2(1,0),new Vector2(-1,0)};

    //float timeBtwMoves = 1.5f;

    //float timer = 1.5f;

    bool canStep = false;

   // private void Awake() 
   // {
   //     TurnManager.Turn += CanStep;
   // }

    public Vector2 Inp()
    {
         

        int i = Random.Range(0, directions.Count);

        return directions[i];
    }

    public List<Vector2> PreTurn()
    {
        int i = Random.Range(0, directions.Count);

        return directions;
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
        int i = Random.Range(0, directions.Count);

        return directions[i];
    }

    
}
