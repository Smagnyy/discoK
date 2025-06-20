using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class floatingText : MonoBehaviour
{
    public TMP_Text thisText;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOShakePosition(2f, 0.05f, 2).SetLoops(-1);
        //thisText.DOColor(new Color(1,1,1, 0), 2f).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
