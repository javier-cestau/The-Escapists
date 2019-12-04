using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FocusInputSound : MonoBehaviour, ISelectHandler
{
    public AudioClip sound;
    AudioSource source { get { return GameObject.FindGameObjectWithTag("SFXSounds").GetComponent<AudioSource>(); } }

    public void OnSelect(BaseEventData eventData) {
        source.PlayOneShot(sound);
    }
}
