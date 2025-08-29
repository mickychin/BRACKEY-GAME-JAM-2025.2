using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Player : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip ButtonSFX;
    [SerializeField] AudioClip CapturedSFX;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playCapturedSFX()
    {
        audioSource.clip = CapturedSFX;
        audioSource.Play();
    }

    public void playButtonSFX()
    {
        audioSource.clip = ButtonSFX;
        audioSource.Play();
    }
}
