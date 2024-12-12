using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorRandom : MonoBehaviour
{
    public static List<Color> colors;

    
    public static Color RandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }
}
