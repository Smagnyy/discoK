using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStPlayer : MonoBehaviour, IHitState
{
    BaseUnit myUnit;
    private void Start()
    {
        myUnit = GetComponentInParent<BaseUnit>();    
    }
    public void DoAction(BaseUnit _bUnit)
    {
        if(_bUnit != null)
        {
            _bUnit.DecreaseHP(myUnit.damage);
            StartCoroutine(Player.Instance.DeleteTilesInTurn(Player.Instance.OwnedTiles.Count));
            //Player.Instance.Hitted();
            //DeleteAllTiles();
            Player.Instance.ChangeDamage();
        }
    }

}
