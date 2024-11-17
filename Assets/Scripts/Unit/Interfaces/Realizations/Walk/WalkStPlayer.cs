using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStPlayer : MonoBehaviour, IWalkState
{
    public void DoAction(Tile __tile)
    {
        
        Player.Instance.StepOnTile(__tile);    
        Player.Instance.StepOnOwnedTile(__tile);   
        Player.Instance.ChangeDamage();
    }

   
}
