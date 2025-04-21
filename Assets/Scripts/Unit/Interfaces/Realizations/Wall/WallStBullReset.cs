using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStBullReset : MonoBehaviour, IWallState
{
    InputsBull inputsBull;

    void Start()
    {
        inputsBull = GetComponentInParent<InputsBull>();
    }

    public void DoAction()
    {
        inputsBull.Stuck();
    }

    
}
