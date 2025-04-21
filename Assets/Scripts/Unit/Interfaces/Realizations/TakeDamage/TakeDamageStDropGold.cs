using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageStDropGold : MonoBehaviour, ITakeDamageState
{
    bool alreadyDropped = false;
    int goldAmount = 5;
    public void DoAction(BaseUnit _bunit)
    {
        if(!alreadyDropped)
            {
                float currHp = _bunit.hp;
                float _maxHp = _bunit.maxHp;
                float hpDiff = currHp/_maxHp;
                Debug.Log("хп дифф " + hpDiff);
                
                if(hpDiff <=0.3f)
                {
                    GlobalContentContainer.Instance.CreatePopUpText($"GOLD! {goldAmount}", transform.position);
                    GlobalContentContainer.Instance.SpawnCoin(transform);
                    alreadyDropped = true;
                }
            }
    }

    
}
