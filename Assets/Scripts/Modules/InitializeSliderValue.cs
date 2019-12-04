using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeSliderValue : MonoBehaviour
{
    public string audioSourceTagName;
    AudioSource audioSource;
    float musicVolume;

    void Awake()
    {

        Screen.SetResolution(640, 480, true);
        audioSource = GameObject.FindGameObjectWithTag(audioSourceTagName).GetComponent<AudioSource>();
        GetComponent<Slider>().onValueChanged.AddListener(SetVolume);
    }

    void Update () {
        audioSource.volume = musicVolume;
	}

    void OnEnable() {
        GetComponent<Slider>().value = audioSource.volume;
        musicVolume = audioSource.volume;
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(audioSourceTagName + "Volume", musicVolume);
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
