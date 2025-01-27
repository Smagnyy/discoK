using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LoseScreenScript : MonoBehaviour
{
   
    public RectTransform loseScreenObj;

    public TMP_Text loseScreenText;

    public RetryButtonScript loseScreenButton;

    public Image loseScreenBackground;
    
    public IEnumerator ShowLoseScreen()
    {

        DOTween.KillAll();
    
        loseScreenObj.gameObject.SetActive(true);
        loseScreenBackground.color = new Color(0,0,0,0f);
        Color endColor = new Color(0,0,0,0.57f);
        loseScreenBackground.DOColor(endColor, 1.14f);

        loseScreenButton.transform.localScale = Vector3.zero;
        //loseScreenButton.color = new Color(1,1, 1,0f);

        loseScreenText.transform.localScale = Vector3.zero;
        loseScreenText.transform.DOScale(1,1.3f);        

        loseScreenText.color = new Color(1,0.2011691f, 0,0f);
        loseScreenText.DOColor(new Color(1,0.2011691f, 0, 1), 2);

        yield return new WaitForSeconds(0.2f);

        

        
        yield return loseScreenButton.transform.DOScale(1,0.2f).WaitForCompletion();     
        
        loseScreenButton.ChangeScale();
        //loseScreenButton.DOColor(new Color(1,1, 1, 1), 2);
    }
}
