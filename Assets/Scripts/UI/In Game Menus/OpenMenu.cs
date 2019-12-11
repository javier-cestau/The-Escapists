using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public AudioClip sound;

    public GameObject objectToActive;
    GameObject inGameMenus;

    Button button { get { return GetComponent<Button>(); } }
    AudioSource source { get { return GameObject.FindGameObjectWithTag("SFXSounds").GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        source.clip = sound;
        source.playOnAwake = false;
        inGameMenus = GameObject.Find("PlayerInGameMenus");
        button.onClick.AddListener(() => Clicked());
    }

    // Update is called once per frame
    void Clicked()
    {
        if(objectToActive.activeInHierarchy) {
            Time.timeScale = 1;
            source.PlayOneShot(sound);
            objectToActive.SetActive(false);
            return;
        }

        Time.timeScale = 0;
        foreach (Transform menu in inGameMenus.transform)
        {
            menu.gameObject.SetActive(false);
        }
        source.PlayOneShot(sound);
        objectToActive.SetActive(true);
    }
}
