using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    //int waves = 3;
    int currentWave = 1;

    public List<BaseUnit> enemyPrefs;

    public List<BaseUnit> spawnedEnemies;

    public Dictionary<BaseUnit, int> enemiesInWave = new Dictionary<BaseUnit, int>();

    Coroutine StartedWave = null;

    int turnsBeforeSpawn;
   

    void Awake() 
    {
        Instance = this;
        InputsPlayer.Counter += UpdateTurnsBeforeSpawn;
        
    }

    private void Start() 
    {
        foreach (var item in enemyPrefs)
        {
            enemiesInWave.Add(item, 1);
        }
    }


    
    void Update()
    {
        
        switch(currentWave)
        {
            case 1:
            if(StartedWave == null)
                StartedWave = StartCoroutine(Wave());            
            break;
            case 2:
            Wave();
            break;
            case 3:
            Wave();
            break;
        }
        

    }

    void UpdateTurnsBeforeSpawn()
    {
        turnsBeforeSpawn++;
        
        if(turnsBeforeSpawn >= 4)
        {
            //turnsBeforeSpawn = 0;
            Debug.LogWarning("прикол");
        }
       
    }


    IEnumerator Wave()
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
        Debug.Log("CONGRATULATIONS!");
        UI_main.Instance.ShowCongratsScreen();
        currentWave++;
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
