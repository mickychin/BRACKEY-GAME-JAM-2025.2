using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX_Animation : MonoBehaviour
{
    [SerializeField] AudioClip venomSFX;

    public void playSFX()
    {
        GetComponent<AudioSource>().Play();
    }

    public void playVenomSFX()
    {
        GetComponent<AudioSource>().clip = venomSFX;
        GetComponent<AudioSource>().Play();
    }
}
