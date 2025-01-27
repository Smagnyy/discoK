using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RetryButtonScript : MonoBehaviour
{
    public UnitAnimationController playerAnimContr;
    AudioSource audioSRC;
    public AudioClip closedHiHatSound;
    public AudioClip openHiHatSound;

    int soundCounter = 0;

    public bool isSelected = false;

    public Color selectedCOlor;

    TMP_Text text;


    Tween shakeTween;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();   
        audioSRC = GetComponent<AudioSource>();
        playerAnimContr = Player.Instance.GetComponent<UnitAnimationController>();
        
        foreach (var item in Player.Instance.baseUnit.bodyParts)
        {
            item.sortingOrder += 1001;
        }
        
        Debug.Log(Player.Instance.baseUnit.bodyParts[0].sortingOrder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScale()
    {
        Vector3 newRotation = new Vector3(0,0,Random.Range(-15,16));
        transform.DORotate(newRotation,0.15f);
        transform.DOScale(Random.Range(0.85f,1.25f),0.15f);
        //transform.DOPunchScale(new Vector3(1.5f, 1.5f,1.5f),0.1f,3,0.15f);
       

        if(isSelected)
        {
            text.color = selectedCOlor;
            audioSRC.clip = closedHiHatSound;
            //audioSRC.PlayOneShot(closedHiHatSound);
            audioSRC.PlayOneShot(GlobalContentContainer.Instance.pMusicParts[soundCounter]);
            soundCounter++;
            if(soundCounter == GlobalContentContainer.Instance.pMusicParts.Count) soundCounter = 0;
            shakeTween.Kill();
            playerAnimContr.StartAnimWithLock("DeathLiftUpArm");
        }
        else
        {
            text.color = Color.white;
            audioSRC.PlayOneShot(GlobalContentContainer.Instance.pMusicParts[soundCounter]);
            soundCounter++;
            if(soundCounter == GlobalContentContainer.Instance.pMusicParts.Count) soundCounter = 0;
            shakeTween.Kill();
            shakeTween = transform.DOShakeScale(1, 0.15f,3).SetLoops(-1);
            playerAnimContr.StartAnimWithLock("DeathJustLie");
        }
    }

    public void ChangeSelected()
    {
        isSelected = !isSelected;
    }

    public void Press()
    {
        DOTween.KillAll();
        audioSRC.clip = openHiHatSound;
        audioSRC.PlayOneShot(openHiHatSound);
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GlobalValues.IsPlayerAlive = true;
        SceneManager.LoadScene(activeSceneIndex);
        
    }

   
}
