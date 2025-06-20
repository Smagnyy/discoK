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

    public floatingText startText;

    ////////////////////////
    
    public Image fadeScreenImage;


    
    ////////////////
    
    public TMP_Text moneyText;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        StartCoroutine(ScreenFader());
        //fadeScreenImage.gameObject.SetActive(true);
        //fadeScreenImage.DOFade(0, 0.50f);
    }

    public void ShowCongratsScreen()
    {
        congratsScreenObj.gameObject.SetActive(true);
        congratsScreenBackground.color = new Color(0,0,0,0f);
        Color endColor = new Color(0,0,0,0.57f);
        congratsScreenBackground.DOColor(endColor, 1.14f);

    }

    IEnumerator ScreenFader()
    {
        fadeScreenImage.gameObject.SetActive(true);
        yield return fadeScreenImage.DOFade(0, 0.50f).WaitForCompletion();
        fadeScreenImage.gameObject.SetActive(false);
    }
    
    public void UpdateMoneyText()
    {
        moneyText.text = GlobalValues.money.ToString();
    }
}
