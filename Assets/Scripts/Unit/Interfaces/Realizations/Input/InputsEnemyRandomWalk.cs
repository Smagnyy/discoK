using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsRandomWalk : MonoBehaviour, Iinputs
{
    List<Vector2> directions = new List<Vector2>{new Vector2(0,1),new Vector2(0,-1),new Vector2(1,0),new Vector2(-1,0)};



   

 
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

    public void StaticCrowdBeh()
    {
        
    }

    
}
