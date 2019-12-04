using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    public AudioClip sound;

    public GameObject objectToActive;
    public GameObject objectToHide;

    Button button { get { return GetComponent<Button>(); } }
    AudioSource source { get { return GameObject.FindGameObjectWithTag("SFXSounds").GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        source.clip = sound;
        source.playOnAwake = false;

        button.onClick.AddListener(() => Clicked());
    }

    // Update is called once per frame
    void Clicked()
    {
        source.PlayOneShot(sound);
        if(objectToActive != null) {
            objectToActive.SetActive(true);
        }
        if(objectToHide != null) {
            objectToHide.SetActive(false);
        }

    }
}
