using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DeathStSpawnObj : MonoBehaviour, IDeathState
{

    public GameObject objToSpawn;

    public void DoAction(BaseUnit _bUnit)
    {
       Instantiate(objToSpawn,_bUnit.transform.position, quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
