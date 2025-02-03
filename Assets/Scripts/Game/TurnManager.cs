using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
   public static TurnManager Instance;
   
    
    

    private void Awake() 
    {
        Instance = this;
        
    }

    public void Turn()
    {

        StartCoroutine(DelayBeforeTurn());
    }

   

    IEnumerator DelayBeforeTurn()
    {
        yield return new WaitForSeconds(0.05f);
        foreach (var item in EnemySpawner.Instance.spawnedEnemies)
        {
            item.GetComponent<TurnFollower>().ActivateInp();
        }
       
        yield break;
    }
}
