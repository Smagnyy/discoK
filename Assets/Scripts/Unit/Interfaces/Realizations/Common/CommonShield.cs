using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CommonShield : MonoBehaviour, ICommonState
{
    public int numberOfShields;
    public List<GameObject> shieldParts;

    int counter = 0;
    int stepsUntilUpdateShield = 3;

    public void DoAction(BaseUnit _bUnit)
    {
        counter++;

        if(counter >= stepsUntilUpdateShield)
        {
            counter = 0;
            ShieldUpdate();
        }
    }

    public void Redo(BaseUnit _bUnit)
    {
        Debug.Log("shield!!! не попало по нему!");
    }


    void Start()
    {
       ShieldUpdate();
        
    }

    
    void ShieldUpdate()
    {
         foreach (var item in shieldParts)
        {
            item.SetActive(false);
        }
        int whatShieldIsActive = Random.Range(0, shieldParts.Count);
        
        for (int i = 0; i < numberOfShields; i++)
        {
            int numb = whatShieldIsActive+i;
            if(numb>= shieldParts.Count)
            {
                numb -=shieldParts.Count;
            }
            shieldParts[numb].SetActive(true);
            
        }
    }
}
