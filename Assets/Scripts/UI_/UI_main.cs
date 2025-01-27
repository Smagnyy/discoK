using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_main : MonoBehaviour
{
    
    public static UI_main Instance;

    public LoseScreenScript loseScreenSCR;

    public TMP_Text timerText;
    public TMP_Text possibleStepsText;

    ////////////////////////
    public RectTransform congratsScreenObj;
    public TMP_Text congratsScreenText;
    public Image congratsScreenBackground;

 


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
   
    public void UpdateTimerText(float _time)
    {
        timerText.text = "Timer " + string.Format("{0:0.0}",_time);
    }

    public void UpdatePossibleStepsText(int _steps)
    {
        possibleStepsText.text = "Possible steps " + _steps;
    }

    public void ShowCongratsScreen()
    {
        congratsScreenObj.gameObject.SetActive(true);
        congratsScreenBackground.color = new Color(0,0,0,0f);
        Color endColor = new Color(0,0,0,0.57f);
        congratsScreenBackground.DOColor(endColor, 1.14f);

    }

    
    
}
