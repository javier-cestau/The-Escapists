using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetKeyBinding : MonoBehaviour
{
     Button button { get { return GetComponent<Button>(); } }
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => ResetValues());
    }

    void ResetValues () {
        KeyManager.instance.ResetValues();
        string[] keysText = {"Up","Down","Right","Left","Action1","Action2","Combat"};
        foreach (string item in keysText)
        {
            GameObject keyRemap = transform.parent.Find(item).gameObject;
            keyRemap.transform.Find("Key").GetComponent<Text>().text = KeyManager.instance.keys[item].ToString();
        }
    }

}
