using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFollower : MonoBehaviour
{
    
    void Awake()
    {
        TurnManager.Turn += ActivateInp;
    }

    void ActivateInp()
    {

    }
   
}
