using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
   
   

    public List<BaseUnit> enemyPrefs;

    public List<BaseUnit> spawnedEnemies;

    public Dictionary<BaseUnit, int> enemiesInWave = new Dictionary<BaseUnit, int>();

    public Coroutine StartedWave = null;

    int turnsBeforeSpawn;
   

    void Awake() 
    {
        Instance = this;
       
        
    }

    private void Start() 
    {
        foreach (var item in enemyPrefs)
        {
            enemiesInWave.Add(item, 1);
        }
    }


    
   

    public void UpdateTurnsBeforeSpawn()
    {
        turnsBeforeSpawn++;
        
        if(turnsBeforeSpawn >= 4)
        {
            //turnsBeforeSpawn = 0;
            Debug.LogWarning("прикол");
        }
       
    }

    public void BeginWave()
    {
        if(StartedWave == null)
                StartedWave = StartCoroutine(Wave());        
    }

    public IEnumerator Wave()
    {
        foreach (var item in enemiesInWave)
        {
            for (int i = 0; i < item.Value; i++)
            {
                
               
                BaseUnit newEnemy = Instantiate(item.Key, TileGenerator.Instance.FindEmpty().transform.position, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
              
                yield return new WaitWhile(() => turnsBeforeSpawn <= 4);
                turnsBeforeSpawn = 0;
                //yield return new WaitForSeconds(2);
            }
           
        }
        
        while (CheckAliveEnemies())
        {
            yield return null;
            Debug.Log("wave!");
        }
        //Debug.Log("CONGRATULATIONS!");
        //UI_main.Instance.ShowCongratsScreen();
        StartCoroutine(MainGC.Instance.EndOfWave());
        StartedWave = null;
    }

    
    public void DeleteEnemyFromList(BaseUnit enemy)
    {
        spawnedEnemies.Remove(enemy);
    }

    bool CheckAliveEnemies()
    {
        if(spawnedEnemies.Count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
