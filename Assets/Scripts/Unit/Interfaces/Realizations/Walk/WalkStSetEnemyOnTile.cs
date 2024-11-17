using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStSetEnemyOnTile : MonoBehaviour, IWalkState
{
    BaseUnit myUnit;


    
    void Start()
    {
        myUnit = GetComponentInParent<BaseUnit>();
    }

    public void DoAction(Tile __tile)
    {
        myUnit.currentTile.SetEmpty();
        myUnit.currentTile = __tile;
        __tile.SetEmpty();

        //Player.Instance.StepOnOwnedTile(__tile);
    }

    
}
