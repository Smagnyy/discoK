using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticLerpSteps : MonoBehaviour
{
    
    public static IEnumerator LerpStep(Transform objToMove, Vector2 _lerpStart, Vector2 _lerpEnd, float speed)
    {
        
        float t = 0;
        float duration = 1;
        
        while(t<= duration)
        {
            t += Time.deltaTime * speed;
            //Debug.Log("t в корутине = " + t);
            objToMove.position = Vector2.Lerp(_lerpStart, _lerpEnd, t);

            yield return null;
        }

        objToMove.position = _lerpEnd;
        
        
        
    }

    public static IEnumerator LerpStepWithBack(Transform objToMove, Vector2 _lerpStart, Vector2 _lerpEnd, float speed)
    {
        
        float t = 0;
        float duration = 1;
        
        while(t<= duration)
        {
            t += Time.deltaTime * speed;
            float formule = -Mathf.Pow(t, 2) + t;
            //Debug.Log("t в корутине = " + t);
            objToMove.position = Vector2.Lerp(_lerpStart, _lerpEnd, formule);

            yield return null;
        }

        objToMove.position = _lerpStart;

        
    }

     public static IEnumerator LerpStepWithBackLocalPos(Transform objToMove, Vector2 _lerpStart, Vector2 _lerpEnd, float speed)
    {
        
        float t = 0;
        float duration = 1;
        
        while(t<= duration)
        {
            t += Time.deltaTime * speed;
            float formule = -Mathf.Pow(t, 2) + t;
            //Debug.Log("t в корутине = " + t);
            objToMove.localPosition = Vector2.Lerp(_lerpStart, _lerpEnd, formule);

            yield return null;
        }

        objToMove.localPosition = _lerpStart;

        
    }
}
