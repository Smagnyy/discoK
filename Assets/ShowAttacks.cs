using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAttacks : MonoBehaviour
{
    public List<AttackPoint> attPoints;
    // Start is called before the first frame update
    
    public void ShowAttackPoints(List<Vector2> positions)
    {
        

        for (int i = 0; i < positions.Count; i++)
        {
            attPoints[i].gameObject.SetActive(true);
            attPoints[i].transform.localPosition = positions[i] * 100; //* 100
            attPoints[i].SetLine(transform.position);
        }
    }

    public void HideAttackPoints()
    {
         for (int i = 0; i < attPoints.Count; i++)
        {
            attPoints[i].gameObject.SetActive(false);
            
        }
    }
}
