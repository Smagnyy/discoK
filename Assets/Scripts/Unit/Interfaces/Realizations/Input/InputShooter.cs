using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputShooter : MonoBehaviour, Iinputs
{
    public Transform PopUpPos;
    public AudioClip reloadSound;
    public AudioClip shootSound;      
    AudioSource audioSRC;
    TurnFollower myTurnFollower;
    
    [SerializeField]
    ShowAttacks showAttacks;

    public BulletPoint bulletPointPrefab;

     [SerializeField]
    BaseUnit bUnit;

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

         Tile wherePlayer = TileGenerator.Instance.FindPlayer();

            Vector2 playerPos = wherePlayer.transform.position;

            List<Vector2> directions = new List<Vector2>();

            if(transform.position.y < playerPos.y) directions.Add(new Vector2(0, -1));
            if(transform.position.y > playerPos.y) directions.Add(new Vector2(0, 1));
            if(transform.position.x > playerPos.x) directions.Add(new Vector2(1, 0));
            if(transform.position.x < playerPos.x) directions.Add(new Vector2(-1, 0));
        if(charges < 3)
        {
            if((transform.position-Player.Instance.transform.position).magnitude <= 2)
            {
                charges+=2;
                int selectedDir = Random.Range(0, directions.Count);
                selectedVec = directions[selectedDir];
                Debug.Log("игрок близко!!!");
            }
            else
                charges++;

            if(charges == 3)
            {
                myTurnFollower.currentNumberOfTurns = 1;
                myTurnFollower.turnsBeforeStep = 1;
            }

                
            
            GlobalContentContainer.Instance.CreatePopUpText($"{charges}/3", PopUpPos.position);
            audioSRC.PlayOneShot(reloadSound);
        }
        
        else
        {
            //myTurnFollower.currentNumberOfTurns= 1;
            //if(showAttacks!=null)
            //    showAttacks.ShowAttackPoints(bUnit.iinputs.PreTurn());
           
            charges = 0;
            Shoot();    
                
            myTurnFollower.currentNumberOfTurns = myTurnFollower.defaultNumberOfTurns;
             myTurnFollower.turnsBeforeStep = myTurnFollower.defaultNumberOfTurns;

            //int selectedDir = Random.Range(0, directions.Count);
            //selectedVec = directions[selectedDir];
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

            Vector2 playerPos = wherePlayer.transform.position;

            if(transform.position.y < playerPos.y) directions.Add(new Vector2(0, 1));
            if(transform.position.y > playerPos.y) directions.Add(new Vector2(0, -1));
            if(transform.position.x > playerPos.x) directions.Add(new Vector2(-1, 0));
            if(transform.position.x < playerPos.x) directions.Add(new Vector2(1, 0));
        }


        return directions;
    }

    void Shoot()
    {
        
        Debug.Log("юнит выстрелил в точки A,B,C");
        for (int i = 0; i < 3; i++)
        {
            Tile availableTile = TileGenerator.Instance.FindTilesWithNoEffect();
            BulletPoint newBulletPoint = Instantiate(bulletPointPrefab, availableTile.transform.position, Quaternion.identity, GlobalContentContainer.Instance.WorldLevelUIObj.transform);
            availableTile.SetEffect();
            newBulletPoint.ownedTile = availableTile;
            
        }
        audioSRC.PlayOneShot(shootSound);
    }

}
