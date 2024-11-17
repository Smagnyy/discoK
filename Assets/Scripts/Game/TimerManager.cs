using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    float timeBtwMoves = 4f;

    float timer = 4f;

    public static event Action OnTimerUpdated;
    
    void Start()
    {
        
    }

    
    void Update()
    {
         timer -= Time.deltaTime;
        UI_main.Instance.UpdateTimerText(timer);

         if(timer <= 0)
        {
            /*
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                 spawnedEnemies[i].GetComponent<InputsEnemy>().EditTimer(timer);
            }*/

            OnTimerUpdated?.Invoke();
           
            timer = timeBtwMoves;
          
        }

    }
}
