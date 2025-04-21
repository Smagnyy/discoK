using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStaticDancers : MonoBehaviour, Iinputs
{
    bool walkInNextTurn = false;

    public bool canBeStunned = false;

    public List<Vector2> directions = new List<Vector2>{new Vector2(0,1),new Vector2(0,-1),new Vector2(1,0),new Vector2(-1,0)};

    public List<Vector2> dirsInNextTurn;
    int nextDirForWalk;
   
    int walkMultiplier =1;
    
 
    public Vector2 Inp()
    {
        canBeStunned = false;
        
        if(walkInNextTurn)
        {
            walkInNextTurn = false;
            return directions[nextDirForWalk] * walkMultiplier;

        }
        else
            StaticCrowdBeh();
        
        RandomBeh();
        
        return Vector2.zero;
    }

    public List<Vector2> PreTurn()
    {   
        List<Vector2> completedDirs = new List<Vector2>();
        dirsInNextTurn.Clear();
        canBeStunned = true;

        if(walkInNextTurn)
        {
            nextDirForWalk = Random.Range(0, directions.Count);
            completedDirs.Add(directions[nextDirForWalk]);
        }
        else
        {
            dirsInNextTurn.AddRange(directions);
        
            int numberOfDeletes = Random.Range(0, directions.Count);

            for (int i = 0; i < numberOfDeletes; i++)
            {
                dirsInNextTurn.RemoveAt(Random.Range(0, dirsInNextTurn.Count));
            }
            completedDirs = dirsInNextTurn;
        }
        


        return completedDirs;
    }

    public void StaticCrowdBeh()
    {
        foreach (var item in dirsInNextTurn)
        {
            RaycastHit2D ray = Physics2D.Raycast((Vector2)transform.position + item, Vector2.zero, 0, GlobalValues.layerMaskOfUnit);
            GlobalContentContainer.Instance.CreatePopUpText("Локоть!", (Vector2)transform.position + item);
            if(ray.collider != null && ray.collider.GetComponent<BaseUnit>() != null)
            {
                ray.collider.GetComponent<BaseUnit>().DecreaseHP(1);
                Debug.Log("ПОПАДАНИЕ");
            }
            else
            {
                Debug.Log("не попал");
            }
        }
        
    }

    void RandomBeh()
    {
        float[] chances = { 0.15f, 0.8f, 0.5f };
        float res = Choose(chances);

        switch (res)
        {
            case 0:
                Debug.Log("первый исход!");
                walkInNextTurn = true;
                 walkMultiplier =1;
            break;
            case 1:
                Debug.Log("второй исход!");     
            break;
            case 2:
                Debug.Log("третий исход!");
                walkInNextTurn = true;
                walkMultiplier = 2;

            break;
        }
    }

     float Choose (float[] probs) 
     {

        float randomPoint = Random.value;

        for (int i= 0; i < probs.Length; i++) {
            if (randomPoint < probs[i]) {
                return i;
            }
            else {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
    
}
