using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsBull : MonoBehaviour, Iinputs
{
    public bool Charged;
    public Vector2 fixedDir;
    TurnFollower myTurnFollower;

     void Start() 
    {
        myTurnFollower = GetComponent<TurnFollower>();
    }
    
    public Vector2 Inp()
    {   
        List<Vector2> directions = new List<Vector2>();
        Vector2 selectedVec = Vector2.zero;
        Tile wherePlayer = TileGenerator.Instance.FindPlayer();
        Vector2 playerPos = wherePlayer.transform.position;

        if(Charged)
        {
            selectedVec = fixedDir;
        }
        else
        {
            if(transform.position.y == playerPos.y || transform.position.x == playerPos.x)
            {
                
                if(transform.position.y == playerPos.y)
                {
                    if(transform.position.x < playerPos.x)
                        fixedDir = new Vector2(1, 0);
                    else if(transform.position.x > playerPos.x)
                        fixedDir = new Vector2(-1, 0);
                }
                else if(transform.position.x == playerPos.x)
                {
                    if(transform.position.y < playerPos.y)
                        fixedDir = new Vector2(0, 1);
                    else if(transform.position.y > playerPos.y)
                        fixedDir = new Vector2(0, -1);
                    
                }
                myTurnFollower.ChangeNumberOfTurns(1);
                Charged = true;
                directions.Add(fixedDir);
                    
                
                
            }
            

            if(transform.position.y < playerPos.y) directions.Add(new Vector2(0, 1));
            if(transform.position.y > playerPos.y) directions.Add(new Vector2(0, -1));
            if(transform.position.x > playerPos.x) directions.Add(new Vector2(-1, 0));
            if(transform.position.x < playerPos.x) directions.Add(new Vector2(1, 0));

            int selectedDir = Random.Range(0, directions.Count);
            selectedVec = directions[selectedDir];
   
        }

        

       

        
        return selectedVec;
    }



    public List<Vector2> PreTurn()
    {
       

        Tile wherePlayer = TileGenerator.Instance.FindPlayer();

        Vector2 playerPos = wherePlayer.transform.position;

        List<Vector2> directions = new List<Vector2>();

        if(transform.position.y < playerPos.y) directions.Add(new Vector2(0, 1));
        if(transform.position.y > playerPos.y) directions.Add(new Vector2(0, -1));
        if(transform.position.x > playerPos.x) directions.Add(new Vector2(-1, 0));
        if(transform.position.x < playerPos.x) directions.Add(new Vector2(1, 0));

        

        return directions;
    }

    public void Stuck()
    {
        Charged = false;
        myTurnFollower.ChangeNumberOfTurns(myTurnFollower.defaultNumberOfTurns);
        fixedDir = Vector2.zero;
    }

}
