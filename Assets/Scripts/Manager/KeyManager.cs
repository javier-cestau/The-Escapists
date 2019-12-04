using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Dictionary<string, KeyCode> defaultKeys = new Dictionary<string, KeyCode>();

    public static KeyManager instance;

    void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
        defaultKeys.Add("Up", KeyCode.W);
        defaultKeys.Add("Down", KeyCode.S);
        defaultKeys.Add("Right", KeyCode.D);
        defaultKeys.Add("Left", KeyCode.A);
        defaultKeys.Add("Action1", KeyCode.Q);
        defaultKeys.Add("Action2", KeyCode.E);
        defaultKeys.Add("Combat", KeyCode.Space);
        InitializeValues();
    }

    void InitializeValues() {
        string[] keysText = {"Up","Down","Right","Left","Action1","Action2","Combat"};
        foreach (string key in keysText)
        {
            keys.Add(key, (KeyCode) PlayerPrefs.GetInt(key, (int) defaultKeys[key]) );
        }
    }
    // Update is called once per frame
    public void ResetValues()
    {

        keys.Clear();
        keys = new Dictionary<string, KeyCode>(defaultKeys);
    }
}
