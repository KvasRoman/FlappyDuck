using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundTypes
{
    death,
    fly
}
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip flySound;
    public AudioClip deathSound;
    AudioSource audioSource;

    public static SoundManager Instance;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("SoundManager should be only one");
        }
    }
    public void PlaySound(SoundTypes type)
    {
        switch (type)
        {
            case SoundTypes.fly: audioSource.PlayOneShot(flySound); break;
            case SoundTypes.death: audioSource.PlayOneShot(deathSound); break;
        }
    }
    public void PlaySound(string type)
    {
        switch (type)
        {
            case "Death": PlaySound(SoundTypes.death); break;
            case "Fly": PlaySound(SoundTypes.fly); break;
        }
    }
}
