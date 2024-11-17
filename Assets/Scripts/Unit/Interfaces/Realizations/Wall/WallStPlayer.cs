using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStPlayer : MonoBehaviour, IWallState
{   
    public int minus = 1;
    public void DoAction()
    {
        if(Player.Instance.OwnedTiles.Count>minus -1 ) // 
        {
            //Player.Instance.AddTileToDelete(minus);
            StartCoroutine(Player.Instance.DeleteTilesInTurn(minus));
            //Player.Instance.DeleteTile(0);
            Player.Instance.UpdateTextOnTile();
            Player.Instance.ChangeDamage();
        }
        else
        {   
            //Player.Instance.AddTileToDelete(Player.Instance.OwnedTiles.Count);
            StartCoroutine(Player.Instance.DeleteTilesInTurn(Player.Instance.OwnedTiles.Count));
            //Player.Instance.DeleteTile(0);
           
        }
    }

    
}
