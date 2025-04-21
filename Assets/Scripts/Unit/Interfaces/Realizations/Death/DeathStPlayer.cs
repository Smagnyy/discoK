using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using DG.Tweening;

public class DeathStPlayer : MonoBehaviour, IDeathState
{
    BaseUnit bUnit;
    Camera cam;

    void Start() 
    {
        cam = Camera.main;    
    }

    public void DoAction(BaseUnit _bUnit)
    {
        bUnit = _bUnit;
        GlobalValues.IsPlayerAlive = false;
        StartCoroutine(PlayDeath());
    }

    IEnumerator PlayDeath()
    {
        //Time.timeScale = 0.15f;
        
        DOTween.To(()=> Time.timeScale, x => Time.timeScale = x, 0.15f, 0.5f);
        
        //cam.orthographicSize = 1.75f;
        cam.DOOrthoSize(1.75f, 0.5f);
        //cam.transform.position = Player.Instance.transform.position + new Vector3(0,0.6f, -10);
        cam.transform.DOMove(Player.Instance.transform.position + new Vector3(bUnit.objToFlip.localScale.x < 0? 0.4f : -0.4f,0.8f, -10), 0.5f);
        bUnit.AnimContr.StopAllCoroutines();
        yield return bUnit.AnimContr.AnimCoroutineWithChange("Death", "DeathJustLie");

        Time.timeScale = 1;
        StartCoroutine(UI_main.Instance.loseScreenSCR.ShowLoseScreen());
    }
    
}
