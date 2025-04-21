using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDamageStDice : MonoBehaviour, IChangeDamageState
{
    CommonStDiceMechanic diceBase;

    void Start() 
    {
        diceBase = GetComponent<CommonStDiceMechanic>();
    }
    public int DoAction(int _damage)
    {
        int newDamage;
        if(diceBase.diceValue == _damage)
        {
            newDamage = _damage;
        }
        else 
        {
            newDamage = 0;
        }
        
        return newDamage;
    }

}
