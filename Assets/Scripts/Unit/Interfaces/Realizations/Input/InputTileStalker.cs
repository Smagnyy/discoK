using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTileStalker : MonoBehaviour, Iinputs
{
    TurnFollower myTF;

    void Start()
    {
        myTF = GetComponent<TurnFollower>();
        myTF.haveToWalk = false;
    }

    void Update()
    {
        if (Player.Instance.OwnedTiles.Count == 0)
        {
            myTF.haveToWalk = false;
        }
        else
            myTF.haveToWalk = true;

    }

    public Vector2 Inp()
    {
        Vector2 tilePos;
       

        if (Player.Instance.OwnedTiles.Count < 4)
        {
            tilePos = Player.Instance.OwnedTiles[Player.Instance.OwnedTiles.Count-1].transform.position;
        }
        else
        {
            tilePos = Player.Instance.OwnedTiles[3].transform.position;
        }

        Vector2 selectedVec = Vector2.zero;
        List<Vector2> directions = new List<Vector2>();

        if (transform.position.y < tilePos.y) directions.Add(new Vector2(0, 1));
        if (transform.position.y > tilePos.y) directions.Add(new Vector2(0, -1));
        if (transform.position.x > tilePos.x) directions.Add(new Vector2(-1, 0));
        if (transform.position.x < tilePos.x) directions.Add(new Vector2(1, 0));

        int selectedDir = Random.Range(0, directions.Count);
        selectedVec = directions[selectedDir];

        return selectedVec;

    }

    public List<Vector2> PreTurn()
    {
        Vector2 tilePos;


        if (Player.Instance.OwnedTiles.Count < 4)
        {
            tilePos = Player.Instance.OwnedTiles[Player.Instance.OwnedTiles.Count-1].transform.position;
        }
        else
        {
            tilePos = Player.Instance.OwnedTiles[3].transform.position;
        }

       
        List<Vector2> directions = new List<Vector2>();

        if (transform.position.y < tilePos.y) directions.Add(new Vector2(0, 1));
        if (transform.position.y > tilePos.y) directions.Add(new Vector2(0, -1));
        if (transform.position.x > tilePos.x) directions.Add(new Vector2(-1, 0));
        if (transform.position.x < tilePos.x) directions.Add(new Vector2(1, 0));



        return directions;
    }

    
}
