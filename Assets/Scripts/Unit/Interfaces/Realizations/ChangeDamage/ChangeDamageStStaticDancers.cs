using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDamageStStaticDancers : MonoBehaviour, IChangeDamageState
{
    InputStaticDancers inputStaticDancers;

    TurnFollower myTurnFollower;

    void Start()
    {
        inputStaticDancers = GetComponentInParent<InputStaticDancers>();
        myTurnFollower = GetComponentInParent<TurnFollower>();
    }

    public int DoAction(int _damage)
    {
        int newDamage = 0;
        if(inputStaticDancers.canBeStunned)
            {
                myTurnFollower.ChangeNumberOfTurns(myTurnFollower.defaultNumberOfTurns);
                inputStaticDancers.canBeStunned = false;
            }
        return newDamage;
    }

    
}
