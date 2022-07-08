using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    AudioMixer Mixer;

    [SerializeField]
    Slider Music_slider;

    [SerializeField]
    Slider Sound_slider;

    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SOUND = "SoundVolume";


    private void Awake()
    {
        Music_slider.onValueChanged.AddListener(SetMusicVolume);
        Sound_slider.onValueChanged.AddListener(SetSoundVolume);
    }

    private void Start()
    {
        Music_slider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        Sound_slider.value = PlayerPrefs.GetFloat(AudioManager.SOUND_KEY, 1f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, Music_slider.value);
        PlayerPrefs.SetFloat(AudioManager.SOUND_KEY, Sound_slider.value);
    }

    void SetMusicVolume(float value)
    {
        Mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    void SetSoundVolume(float value)
    {
        Mixer.SetFloat(MIXER_SOUND, Mathf.Log10(value) * 20);
    }

}
