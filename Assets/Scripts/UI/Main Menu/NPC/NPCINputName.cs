using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class NPCINputName : MonoBehaviour
{
    public GameObject errorMessage;
    public AudioClip sound;
    string currentName;
    InputField input;
    AudioSource source { get { return GameObject.FindGameObjectWithTag("SFXSounds").GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        errorMessage.SetActive(false);
        input = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {

        if(SelectorNPC.currentNPCSelected != null) {

            if(SelectorNPC.isCurrentNPCSelectedClicked) {
                input.Select();
                SelectorNPC.isCurrentNPCSelectedClicked = false;
                input.text = "";
            }

            if(currentName != SelectorNPC.currentNPCSelected.characterName) {
                input.text = SelectorNPC.currentNPCSelected.characterName;
                currentName = SelectorNPC.currentNPCSelected.characterName;
            }

        }
    }

    void OnGUI() {
        if(input.isFocused && Input.GetKey(KeyCode.Return)) {
            if(input.text.Length >= 3) {
                SelectorNPC.currentNPCSelected.characterName = !SelectorNPC.currentNPCSelected.isInmate && !Regex.Match(input.text, "Officer").Success ? "Officer " + input.text : input.text;
                SelectorNPC.currentNPCSelected.name = SelectorNPC.currentNPCSelected.characterName;
            } else {
                StartCoroutine(ShowErrorMessage());
                source.PlayOneShot(sound);
            }
        }
    }

    IEnumerator ShowErrorMessage() {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        errorMessage.SetActive(false);
    }
}
