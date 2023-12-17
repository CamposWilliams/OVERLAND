using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumenControlador : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider soundSlider;

  
    public string musicVolumeParameter = "Soundtracks";
    public string soundVolumeParameter = "Sonidos";

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        musicSlider.value = PlayerPrefs.GetFloat(musicVolumeParameter, 1f);
        soundSlider.value = PlayerPrefs.GetFloat(soundVolumeParameter, 1f);

      
        SetMusicVolume(musicSlider.value);
        SetSoundVolume(soundSlider.value);
    }

    public void SetMusicVolume(float volume)
    {
        //Debug.Log("" + volume);
        audioMixer.SetFloat(musicVolumeParameter, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(musicVolumeParameter, volume);
    }

    public void SetSoundVolume(float volume)
    {
        //Debug.Log("" + volume);
        audioMixer.SetFloat(soundVolumeParameter, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(soundVolumeParameter, volume);
    }
  
}