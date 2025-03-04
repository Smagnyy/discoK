using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRaying : MonoBehaviour
{
    public static States RayAll(Vector2 dir, out GameObject raycastedObject, Transform objPos)
    {
        RaycastHit2D[] ray = Physics2D.RaycastAll((Vector2)objPos.position + dir, Vector2.zero);

        //Debug.Log("ray length "+ray.Length);
        States s = States.Idle;
        raycastedObject = null;

        if(ray.Length > 0)
        {   
            
            
            for(int i = 0; i < ray.Length; i++ )
            {
                
                /*
                if(ray[i].collider.GetComponent<Stone>() != null)
                {   
                    
                    ray[i].collider.GetComponent<Stone>().Push(dir);
                }
                */
                if(ray[i].collider. GetComponent<Tile>() != null)
                {
                    //raycastedObject = ray[i].collider. GetComponent<Tile>();
                    raycastedObject = ray[i].collider.gameObject;
                    s = States.Walk;
                }
                else if (ray[i].collider.GetComponent<BaseUnit>() != null)
                {
                    raycastedObject = ray[i].collider.gameObject;
                    Debug.Log(ray[i].collider.gameObject);
                    return States.Hit;
                }
            }
            
        }

        else
        {
           
            s = States.Wall;            
            //destination += dir;
            //startPosForBackStep = transform.position;
            //DecreaseSteps();
        }

        return s;
    }
}
