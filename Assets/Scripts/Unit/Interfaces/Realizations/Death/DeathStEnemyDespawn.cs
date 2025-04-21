using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStEnemyDespawn : MonoBehaviour, IDeathState
{
    public void DoAction(BaseUnit _bUnit)
    {

        EnemySpawner.Instance.DeleteEnemyFromList(_bUnit);
        Destroy(_bUnit.gameObject);

    }

   
}
