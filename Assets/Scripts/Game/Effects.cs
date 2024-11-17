using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public static Effects Instance;
    private void Awake() 
    {
        Instance = this;
    }

    public static IEnumerator Shake(int countOfShakes, GameObject objToShake) // либо передавать надо не GameObject, а Transform
    {
        countOfShakes = 5;
        float offset = 0.05f;
        float t = 0;
        Vector2 currentPos;

        for (int i = 1; i <= countOfShakes; i++)
        {
            currentPos = objToShake.transform.localPosition;
            t = 0;
            offset *= -1;
            Vector2 newPos = i == countOfShakes ? newPos = Vector2.zero : newPos = new Vector2(offset, 0);
            
            while((Vector2)objToShake.transform.localPosition != newPos)
            {
                objToShake.transform.localPosition = Vector2.Lerp(currentPos, newPos, t);
                t += Time.deltaTime*14;
                yield return null;
            } 
        }

        objToShake.transform.localPosition = Vector2.zero;
    }

    public static IEnumerator ShakeSin(GameObject objToShake, float amountOfShakes, float offset, float speed) // либо передавать надо не GameObject, а Transform
    {
       
        
        float t = 0;
        float currPosY = objToShake.transform.localPosition.y;

        float formule = offset * Mathf.Sin(6.3f * t * amountOfShakes);
       
        
           
            //offset *= -1;           
            
            while(t<=1)
            {
                objToShake.transform.localPosition = new Vector2(formule, 0);
                t += Time.deltaTime*speed;
                formule = offset * Mathf.Sin(6.3f * t * amountOfShakes);
                yield return null;
            } 
        

        objToShake.transform.localPosition = Vector2.zero;
    }

    public static IEnumerator SinusoidalMove(GameObject objToMove)
    {

        yield return new WaitForSeconds(2);
        float t = 0;
        float offset = 0.05f;
        float formule = Mathf.Sin(50* t);

        Vector2 currentPos = objToMove.transform.position;
        Vector2 newPos = new Vector2(0, currentPos.y + offset);
        while (true)
        {
            formule = Mathf.Sin(6.3f* 5* t);
            float formule2 = Mathf.Cos(6.3f*5*t);
            t+=Time.deltaTime/5;
            objToMove.transform.localPosition = new Vector2(formule2, formule);
            yield return null;

            if(t>=1) t = 0;
        }
        //objToMove.transform.localPosition = Vector2.zero;
       
    }

    public static IEnumerator SinusoidalMoveDegToRad(GameObject objToMove, bool needPauseOnStart)
    {

        if(needPauseOnStart) yield return new WaitForSeconds(2);
        float t = 0;
        float a = Mathf.Asin(objToMove.transform.localPosition.y);
        Debug.Log("a = "+ a);
        t = a * Mathf.Rad2Deg;
        Debug.Log("t = "+ t);
        //float offset = 0.05f;
        float formule = Mathf.Sin(t * Mathf.Deg2Rad);

       
        while (true)
        {
            formule = Mathf.Sin(t * Mathf.Deg2Rad);
            float formule2 = Mathf.Cos(t * Mathf.Deg2Rad) * 0;
            
            objToMove.transform.localPosition = new Vector2(formule2, formule);
            t+=Time.deltaTime*50;
            if(t>=360) t = 0;
            yield return null;
            //Debug.Log(t);

           
        }
        //objToMove.transform.localPosition = Vector2.zero;
       
    }

    public static IEnumerator SinusoidalMoveDegToRadToZeroPoint(GameObject objToMove, bool needPauseOnStart)
    {

        if(needPauseOnStart) yield return new WaitForSeconds(2);
        float t = 0;
        float a = Mathf.Asin(objToMove.transform.localPosition.y);
        Debug.Log("a = "+ a);
        t = a * Mathf.Rad2Deg;
        Debug.Log("t = "+ t);
        //float offset = 0.05f;
        float formule = Mathf.Sin(t * Mathf.Deg2Rad);

       
        while (t<360)
        {
            formule = Mathf.Sin(t * Mathf.Deg2Rad);
            float formule2 = Mathf.Cos(t * Mathf.Deg2Rad) * 0;
            
            objToMove.transform.localPosition = new Vector2(formule2, formule);
            t+=Time.deltaTime*50;
            
            yield return null;
            Debug.Log(t);

           
        }
        objToMove.transform.localPosition = Vector2.zero;
       
    }

   

    public static IEnumerator Fade(SpriteRenderer objToFade, Color startColor, Color endColor, float speed)
    {
        float t = 0; 
        
        while (t <= 1)
        {   
            //Debug.Log("ColorLerp " + t + "ColorLerp " + objToFade.color);
            Color newColor = Color.Lerp(startColor,endColor,t);
            objToFade.color = newColor;
            t += Time.deltaTime*speed;
            yield return null;

            

        }
        
        objToFade.color = endColor;
    }

}
