using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class InputGoldStalker : MonoBehaviour, Iinputs
{

    public int moneyAmount;
    public Vector2 Inp()
    {
        Vector2 selectedVec = Vector2.zero;
        List<Vector2> directions = new List<Vector2>();

        if(GlobalContentContainer.Instance.spawnedCoins.Count != 0)
        {
            directions = GoldStalkerBeh();
            int selectedDir = Random.Range(0, directions.Count);
            selectedVec = directions[selectedDir];
        }
            
        return selectedVec;
    }

    public List<Vector2> PreTurn()
    {
         if(GlobalContentContainer.Instance.spawnedCoins.Count != 0)
            return GoldStalkerBeh();
        
        return null;
    }


    Vector2 FindClosestCoin()
    {
        float minDist = (transform.position - GlobalContentContainer.Instance.spawnedCoins[0].transform.position).sqrMagnitude;
        int indexOfclosestCoin= 0;
               
        if(GlobalContentContainer.Instance.spawnedCoins.Count > 1)
        {
            for (int i = 1; i < GlobalContentContainer.Instance.spawnedCoins.Count; i++)
            {
            float currDist = (transform.position - GlobalContentContainer.Instance.spawnedCoins[i].transform.position).sqrMagnitude;
                if(currDist < minDist)
                {
                    minDist = currDist;
                    indexOfclosestCoin = i;
                }
            }
        }
        return GlobalContentContainer.Instance.spawnedCoins[indexOfclosestCoin].transform.position;
    }

    List<Vector2> GoldStalkerBeh()
    {
        List<Vector2> _dirs = new List<Vector2>();
        
             Vector2 closestCoinPos = FindClosestCoin();

     

            if (transform.position.y < closestCoinPos.y) _dirs.Add(new Vector2(0, 1));
            if (transform.position.y > closestCoinPos.y) _dirs.Add(new Vector2(0, -1));
            if (transform.position.x > closestCoinPos.x) _dirs.Add(new Vector2(-1, 0));
            if (transform.position.x < closestCoinPos.x) _dirs.Add(new Vector2(1, 0));

    

        return _dirs;
    }
}
