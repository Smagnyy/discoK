using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStDamageByWall : MonoBehaviour, IWallState
{
    BaseUnit myUnit;
    public int damage = 1;
    private void Start() 
    {
        myUnit = GetComponentInParent<BaseUnit>();
    }

    public void DoAction()
    {
        myUnit.DecreaseHP(damage);
    }

   
}
