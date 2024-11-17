using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsEnemyKnowPlayerPos : MonoBehaviour, Iinputs
{
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


     bool canStep = false;

    public void CanStep()
    {
        canStep = true;
    }
    private void Awake() 
    {
        TurnManager.Turn += CanStep;
    }

    Vector2 Turn()
    {
        Vector2 selectedVec = Vector2.zero;

        Tile wherePlayer = TileGenerator.Instance.FindPlayer();

        Vector2 a = wherePlayer.transform.position;

        List<Vector2> directions = new List<Vector2>();

        if(transform.position.y < a.y) directions.Add(new Vector2(0, 1));
        if(transform.position.y > a.y) directions.Add(new Vector2(0, -1));
        if(transform.position.x > a.x) directions.Add(new Vector2(-1, 0));
        if(transform.position.x < a.x) directions.Add(new Vector2(1, 0));

        int selectedDir = Random.Range(0, directions.Count);
        selectedVec = directions[selectedDir];

        return selectedVec;
    }

}
