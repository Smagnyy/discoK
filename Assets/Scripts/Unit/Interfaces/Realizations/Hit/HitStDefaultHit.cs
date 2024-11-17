using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStDefaultHit : MonoBehaviour, IHitState
{
    BaseUnit myUnit;
     void Start()
    {
        myUnit = GetComponentInParent<BaseUnit>();
    }
    public void DoAction(BaseUnit _bUnit)
    {
        _bUnit.DecreaseHP(myUnit.damage);
    }

   
   

   
}
