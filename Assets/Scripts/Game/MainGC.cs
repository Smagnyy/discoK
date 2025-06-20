using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainGC : MonoBehaviour
{
    public static MainGC Instance;
    float defaultCameraSize = 5;

    bool isStart;

    Coroutine StartedGame;

    public Transform ShopPlayerPos;
    public TMP_Text textBackToField;

    Vector2 currentPlayerPos;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isStart = false;
        Camera.main.transform.position = new Vector3(0,0.5f, -10);
        Camera.main.orthographicSize = 1.15f;
        //Player.Instance.baseUnit.AnimContr.StartAnimWithLock("Death");
        GlobalValues.IsPlayerAlive = false;
        textBackToField.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !isStart)
        {
            isStart = true;
            GlobalValues.IsPlayerAlive = true;
            Camera.main.transform.DOLocalMoveY(0, 0.5f);
            Camera.main.DOOrthoSize(defaultCameraSize, 0.5f);
            UI_main.Instance.startText.gameObject.SetActive(false);
            StartedGame = StartCoroutine(GameCycle());
        }

        if(!GlobalValues.CanWalk)
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
               StartCoroutine(StartNewWave());
            }
        }
    }



    IEnumerator GameCycle()
    {
        yield return null;
        EnemySpawner.Instance.BeginWave();
    }

    public IEnumerator EndOfWave()
    {
        yield return new WaitForSeconds(0.5f);
        ShopWindow.Instance.OpenShop();
        
        currentPlayerPos = Player.Instance.transform.position;
        Player.Instance.transform.position = ShopPlayerPos.position;
        GlobalValues.CanWalk = false;

        Camera.main.DOOrthoSize(1.75f, 1.5f);
        Camera.main.transform.DOMove(ShopPlayerPos.transform.position + new Vector3(0,1.5f,-10), 1.5f);
        textBackToField.gameObject.SetActive(true);
    }

    public IEnumerator StartNewWave()
    {
        yield return new WaitForSeconds(0.1f);
        ShopWindow.Instance.CloseShop();
        Player.Instance.transform.position = currentPlayerPos;
        GlobalValues.CanWalk = true;
        EnemySpawner.Instance.BeginWave();

        
        Camera.main.DOOrthoSize(defaultCameraSize, 1.5f);
        Camera.main.transform.DOLocalMoveY(0, 1.5f);
        textBackToField.gameObject.SetActive(false);
    }
}
