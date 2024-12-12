using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonStPlayerHeal : MonoBehaviour, ICommonState
{

    int counter = 0;
     [SerializeField]
    int stepsForHeal;

    public void DoAction(BaseUnit _bUnit)
    {
        if(_bUnit.hp < _bUnit.maxHp)
        {
            counter++;
        }
        if(counter >= stepsForHeal)
        {
            _bUnit.hp++;
            _bUnit.hBar.UpdateHealthBar(_bUnit.hp, _bUnit.maxHp);
            Reset();
        }
    }
    
    public void Reset()
    {
        counter = 0;
    }

   
}
