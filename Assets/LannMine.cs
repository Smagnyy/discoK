using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LannMine : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.GetComponent<BaseUnit>())
        {
            other.GetComponent<BaseUnit>().DecreaseHP(1);
            Destroy(this.gameObject);
        }
   }
}
