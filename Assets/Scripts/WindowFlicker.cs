using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WindowFlicker : MonoBehaviour
{
    public List<Light2D> lights; 
    public float minIntense = 0.87f; 
    public float step = 0.25f;
    public int speed = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in lights)
        {
            
            item.intensity = minIntense + Mathf.PingPong(Time.time/speed, step);
        }
        
    }
}
