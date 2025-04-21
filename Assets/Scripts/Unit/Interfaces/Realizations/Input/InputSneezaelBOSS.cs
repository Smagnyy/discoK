using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSneezaelBOSS : MonoBehaviour, Iinputs
{
    public Vector2 Inp()
    {
        throw new System.NotImplementedException();
    }

    public List<Vector2> PreTurn()
    {
        throw new System.NotImplementedException();
    }

   void RandomBeh()
    {
        float[] chances = { 0.15f, 0.8f, 0.5f };
        float res = Choose(chances);

        switch (res)
        {
            case 0:
                Debug.Log("первый исход!");
                //walkInNextTurn = true;
                 //walkMultiplier =1;
            break;
            case 1:
                Debug.Log("второй исход!");     
            break;
            case 2:
                Debug.Log("третий исход!");
                //walkInNextTurn = true;
                //walkMultiplier = 2;

            break;
        }
    }

     float Choose (float[] probs) 
     {

        float randomPoint = Random.value;

        for (int i= 0; i < probs.Length; i++) {
            if (randomPoint < probs[i]) {
                return i;
            }
            else {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
