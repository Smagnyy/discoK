using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CommonStDiceMechanic : MonoBehaviour, ICommonState
{
    public int diceValue;
    public TMP_Text diceValueText;

    int maxCounter = 3;
    int counter = 3;
    public void DoAction(BaseUnit _bUnit)
    {
        counter--;
        if(counter < 1)
        {
            counter = maxCounter;
            SetNewValue();
        }
    }

    public void Redo(BaseUnit _bUnit)
    {
        SetNewValue();
    }

    void SetNewValue()
    {
        diceValue = Random.Range(1, 7);
        diceValueText.text = diceValue.ToString();
    }
    
}
