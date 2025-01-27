using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContentContainer : MonoBehaviour
{
    public static GlobalContentContainer Instance;

    public List<AudioClip> pMusicParts;

    public List<AudioClip> TagGameSounds;

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
}
