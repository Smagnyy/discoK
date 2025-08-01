using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsRook : MonoBehaviour, Iinputs
{
     public Vector2 Inp()
    {
        Vector2 selectedVec = Vector2.zero;

        //Tile wherePlayer = TileGenerator.Instance.FindPlayer();

        //Vector2 a = wherePlayer.transform.position;
        Vector2 playerPos = Player.Instance.transform.position;
        List<Vector2> directions = new List<Vector2>();

     //   if(transform.position.y < playerPos.y) directions.Add(new Vector2(0, playerPos.y));
     //   if(transform.position.y > playerPos.y) directions.Add(new Vector2(0, playerPos.y));
     //   if(transform.position.x > playerPos.x) directions.Add(new Vector2(playerPos.x, 0));
     //   if(transform.position.x < playerPos.x) directions.Add(new Vector2(playerPos.x, 0));

        if(transform.position.y != playerPos.y) directions.Add(new Vector2(0, -(transform.position.y - playerPos.y)));
        if(transform.position.x != playerPos.x) directions.Add(new Vector2(-(transform.position.x -playerPos.x), 0));

        int selectedDir = Random.Range(0, directions.Count);
        selectedVec = directions[selectedDir];

        return selectedVec;
    }


  


    Vector2 GetDir()
    {
        Vector2 selectedVec = Vector2.zero;

        //Tile wherePlayer = TileGenerator.Instance.FindPlayer();

        //Vector2 a = wherePlayer.transform.position;
        Vector2 playerPos = Player.Instance.transform.position;
        List<Vector2> directions = new List<Vector2>();

     //   if(transform.position.y < playerPos.y) directions.Add(new Vector2(0, playerPos.y));
     //   if(transform.position.y > playerPos.y) directions.Add(new Vector2(0, playerPos.y));
     //   if(transform.position.x > playerPos.x) directions.Add(new Vector2(playerPos.x, 0));
     //   if(transform.position.x < playerPos.x) directions.Add(new Vector2(playerPos.x, 0));

        if(transform.position.y != playerPos.y) directions.Add(new Vector2(0, -(transform.position.y - playerPos.y)));
        if(transform.position.x != playerPos.x) directions.Add(new Vector2(-(transform.position.x -playerPos.x), 0));

        int selectedDir = Random.Range(0, directions.Count);
        selectedVec = directions[selectedDir];

        return selectedVec;
    }

    public List<Vector2> PreTurn()
    {
        Vector2 selectedVec = Vector2.zero;

        //Tile wherePlayer = TileGenerator.Instance.FindPlayer();

        //Vector2 a = wherePlayer.transform.position;
        Vector2 playerPos = Player.Instance.transform.position;
        List<Vector2> directions = new List<Vector2>();

     //   if(transform.position.y < playerPos.y) directions.Add(new Vector2(0, playerPos.y));
     //   if(transform.position.y > playerPos.y) directions.Add(new Vector2(0, playerPos.y));
     //   if(transform.position.x > playerPos.x) directions.Add(new Vector2(playerPos.x, 0));
     //   if(transform.position.x < playerPos.x) directions.Add(new Vector2(playerPos.x, 0));

        if(transform.position.y != playerPos.y) directions.Add(new Vector2(0, -(transform.position.y - playerPos.y)));
        if(transform.position.x != playerPos.x) directions.Add(new Vector2(-(transform.position.x -playerPos.x), 0));

        
        

        return directions;
    }
}
