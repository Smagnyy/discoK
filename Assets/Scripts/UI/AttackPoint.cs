using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2 (0.75f + Mathf.PingPong(Time.time/3, 0.25f), 0.75f + Mathf.PingPong(Time.time/3, 0.25f));
    }

    public void SetLine(Vector2 dir)
    {
        line.SetPosition(0, dir);
        line.SetPosition(1, transform.position);
    }
}
