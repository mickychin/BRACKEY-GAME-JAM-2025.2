using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider MusicSlider;
    public AudioMixer audioMixer;
    public AudioMixer MusicMixer;

    [SerializeField] GameObject Setting;

    private void Start()
    {
        SFXSlider.value = FindObjectOfType<GameMaster>().SFXVolume;
        MusicSlider.value = FindObjectOfType<GameMaster>().MusicVolume;
        audioMixer.SetFloat("Volume", Mathf.Log10(SFXSlider.value) * 20 );
        MusicMixer.SetFloat("Volume", Mathf.Log10(MusicSlider.value) * 20);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Setting.activeSelf)
            {
                Setting.SetActive(false);
            }
            else
            {
                Setting.SetActive(true);
            }
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        FindObjectOfType<GameMaster>().SFXVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        FindObjectOfType<GameMaster>().MusicVolume = volume;
    }
}
