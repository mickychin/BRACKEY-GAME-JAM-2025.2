using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] AudioClip walkMusic;
    [SerializeField] AudioClip encounterMusic;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkMusic()
    {
        audioSource.Stop();
        audioSource.clip = walkMusic;
        audioSource.Play();
    }

    public void PlayEncounterMusic()
    {
        audioSource.Stop();
        audioSource.clip = encounterMusic;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
