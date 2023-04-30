using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class VolumeSettings : MonoBehaviour
{
   [SerializeField] AudioMixer mixer;
   [SerializeField] Slider MusicSlider;
   [SerializeField] Slider SFXSlider;
   public const string MIXER_MUSIC = "MusicVolume";
   public const string MIXER_SFX = "SFXVolume";

    private void Awake() {
        MusicSlider.onValueChanged.AddListener(SetMusicVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Start() {
        MusicSlider.value= PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY,1f);
       SFXSlider.value= PlayerPrefs.GetFloat(AudioManager.SFX_KEY,1f);
        
    }

    private void OnDisable() {
    PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY,MusicSlider.value);
    PlayerPrefs.SetFloat(AudioManager.SFX_KEY,SFXSlider.value);

    }

    public void SetMusicVolume(float value){
        mixer.SetFloat(MIXER_MUSIC,Mathf.Log10(value)*20);
    }
    public void SetSFXVolume(float value){
        mixer.SetFloat(MIXER_SFX,Mathf.Log10(value)*20);
    }

}
