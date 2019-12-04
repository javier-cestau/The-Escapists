using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameValidation : MonoBehaviour
{
    public Button buttonToDisable;
    public GameObject errorMessage;
    public AudioClip errorSound;

    AudioSource source { get { return GameObject.FindGameObjectWithTag("SFXSounds").GetComponent<AudioSource>(); } }

    void Start()
    {
        errorMessage.SetActive(false);
    }

    public void ValidateName(string name) {
        if(name.Length < 3) {
            source.PlayOneShot(errorSound);
            buttonToDisable.interactable = false;
            StartCoroutine(ShowErrorMessage());
            return;
        }

        buttonToDisable.interactable = true;

    }

    IEnumerator ShowErrorMessage() {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        errorMessage.SetActive(false);
    }
}
