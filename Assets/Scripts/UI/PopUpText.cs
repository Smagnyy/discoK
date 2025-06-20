using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PopUpText : MonoBehaviour
{
    public TMP_Text textObj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PopUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillText(string text)
    {
        textObj.text = text;
    }

    IEnumerator PopUp()
    {
        textObj.color = new Color(1,1,1,1f);
        textObj.transform.localScale = Vector3.zero;

        textObj.transform.DOScale(Random.Range(0.9f, 1.2f),1.3f);
        textObj.transform.DOLocalMoveY(Random.Range(0.5f, 0.9f), 1.3f);     
        textObj.transform.DORotate(new Vector3(0,0,Random.Range(-8, 9)),0.1f);

        yield return new WaitForSeconds(0.9f);
        
        yield return textObj.DOColor(new Color(0,0,0,0f), 1.14f).WaitForCompletion();

        Destroy(this.gameObject);
    }

    private void OnEnable() 
    {
        StartCoroutine(PopUp());
    }
}
