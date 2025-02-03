using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundTypes
{
    Go, Hit, GetDamage, Wall
}

public class UnitSoundSys : MonoBehaviour
{
    public AudioClip walkSound;

    public AudioClip wallCrashSound;
    AudioSource audioSRC;

    public Dictionary<SoundTypes, AudioClip> clips = new Dictionary<SoundTypes, AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        audioSRC = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        audioSRC.pitch = 1+ Random.Range(-0.15f,0.15f);
        
        //audioSRC.clip = GlobalContentContainer.Instance.TagGameSounds[Random.Range(0,GlobalContentContainer.Instance.TagGameSounds.Count)];
        audioSRC.PlayOneShot(clip);
    }
}
