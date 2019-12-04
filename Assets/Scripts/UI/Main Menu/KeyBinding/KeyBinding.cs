using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour
{
    GameObject currentKey;
    public AudioClip wrongSound;

    Dictionary<string, KeyCode> tmpKeys;

    float waitWrongTimeExecution;

    AudioSource source { get { return GameObject.FindGameObjectWithTag("SFXSounds").GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        waitWrongTimeExecution = wrongSound.length;
        Vector3 keyRemapPosition = GameObject.Find("Remap Keys").GetComponent<RectTransform>().position;
        keyRemapPosition = new Vector3(keyRemapPosition.x + 60, keyRemapPosition.y - 40, keyRemapPosition.z);
        string[] keysText = {"Up","Down","Right","Left","Action1","Action2","Combat"};
        foreach (string item in keysText)
        {
            keyRemapPosition = new Vector3(keyRemapPosition.x, keyRemapPosition.y - 75, keyRemapPosition.z);
            GameObject keyRemap = Instantiate(Resources.Load("Prefabs/KeyRemap"), keyRemapPosition, Quaternion.identity, transform.parent) as GameObject;
            keyRemap.transform.localScale = new Vector3(.8f,.8f, 1);
            keyRemap.name = item;
            keyRemap.transform.Find("Key").GetComponent<Text>().text = KeyManager.instance.keys[item].ToString();
            keyRemap.transform.Find("Action").GetComponent<Text>().text = item + ":";
            keyRemap.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => ChangeKey(keyRemap));
        }

    }

    void OnDisable() {
        if(currentKey != null) {
            currentKey.transform.Find("Key").GetComponent<Text>().text = KeyManager.instance.keys[currentKey.name].ToString();
            currentKey = null;
        }
        tmpKeys = null;
    }

    void OnGUI()
    {
        if(currentKey != null) {
            Event e = Event.current;
            if(e.isKey) {
                if(!tmpKeys.ContainsValue(e.keyCode)) {
                    KeyManager.instance.keys[currentKey.name] = e.keyCode;
                    currentKey.transform.Find("Key").GetComponent<Text>().text = e.keyCode.ToString();
                    PlayerPrefs.SetInt(currentKey.name, (int) e.keyCode);
                    currentKey = null;
                } else {
                    if(!source.isPlaying) {
                        source.PlayOneShot(wrongSound);
                    }
                }
            }
        }
    }

    void ChangeKey(GameObject clicked) {
        if(currentKey == null) {
            currentKey = clicked;
            tmpKeys =  new Dictionary<string, KeyCode>(KeyManager.instance.keys);
            tmpKeys[currentKey.name] = KeyCode.None;
            clicked.transform.Find("Key").GetComponent<Text>().text = "...";
        }
    }

}
