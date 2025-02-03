using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBerserk : MonoBehaviour, Iinputs
{
    public Transform PopUpPos;
    public AudioClip gulpSound;   
    AudioSource audioSRC;
    TurnFollower myTurnFollower;
    

    int charges = 0;

    int turnsInCharge = 0; 


    void Start() 
    {
        myTurnFollower = GetComponent<TurnFollower>();
        audioSRC = GetComponent<AudioSource>();
    }

    public Vector2 Inp()
    {
         Vector2 selectedVec = Vector2.zero;
        if(charges < 3)
        {
            if(charges == 2)
                myTurnFollower.currentNumberOfTurns = 1;
            charges++;
            GlobalContentContainer.Instance.CreatePopUpText($"{charges}/3", PopUpPos.position);
            audioSRC.PlayOneShot(gulpSound);
        }
        
        else
        {
            myTurnFollower.currentNumberOfTurns= 1;
            turnsInCharge++;
            if(turnsInCharge > 3) 
            {
                charges = 0;
                turnsInCharge = 0;
                myTurnFollower.currentNumberOfTurns = myTurnFollower.defaultNumberOfTurns;
            }
            Tile wherePlayer = TileGenerator.Instance.FindPlayer();

            Vector2 a = wherePlayer.transform.position;

            List<Vector2> directions = new List<Vector2>();

            if(transform.position.y < a.y) directions.Add(new Vector2(0, 1));
            if(transform.position.y > a.y) directions.Add(new Vector2(0, -1));
            if(transform.position.x > a.x) directions.Add(new Vector2(-1, 0));
            if(transform.position.x < a.x) directions.Add(new Vector2(1, 0));

            int selectedDir = Random.Range(0, directions.Count);
            selectedVec = directions[selectedDir];
        }
       

       

        return selectedVec;
    }



    public List<Vector2> PreTurn()
    {
        List<Vector2> directions = new List<Vector2>();
        if(charges < 3)
        {
            directions.Add(new Vector2(0, 0));
        }
        else
        {
             Tile wherePlayer = TileGenerator.Instance.FindPlayer();

            Vector2 a = wherePlayer.transform.position;

            if(transform.position.y < a.y) directions.Add(new Vector2(0, 1));
            if(transform.position.y > a.y) directions.Add(new Vector2(0, -1));
            if(transform.position.x > a.x) directions.Add(new Vector2(-1, 0));
            if(transform.position.x < a.x) directions.Add(new Vector2(1, 0));
        }

       

        

        return directions;
    }

}
