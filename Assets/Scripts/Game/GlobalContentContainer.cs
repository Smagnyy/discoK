using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GlobalContentContainer : MonoBehaviour
{
    public static GlobalContentContainer Instance;

    public List<AudioClip> pMusicParts;

    public List<AudioClip> TagGameSounds;

    public PopUpText popUpTextPrefab;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePopUpText(string text, Vector2 pos)
    {
        PopUpText newPopUpText = Instantiate(popUpTextPrefab);
        newPopUpText.transform.position = pos; //+ new Vector3(0,0,10)
        newPopUpText.FillText(text);
    }
}
