using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMode : MonoBehaviour
{
    bool fullScreen;
    void Start()
    {
        fullScreen = PlayerPrefs.GetInt("ScreenMode", 1) == 1;
        SetResolution();
        transform.Find("ArrowLeft").GetComponent<Button>().onClick.AddListener(() => ChangeScreenMode());
        transform.Find("ArrowRight").GetComponent<Button>().onClick.AddListener(() => ChangeScreenMode());
    }

   void ChangeScreenMode() {
        fullScreen = !fullScreen;
        SetResolution();
        PlayerPrefs.SetInt("ScreenMode", Convert.ToInt32(fullScreen));
   }

   void SetResolution() {
        Screen.SetResolution(fullScreen ? 1920 : 1200, fullScreen ? 1080 : 768, fullScreen );
        GetComponentInChildren<Text>().text = fullScreen ? "Full" : "Window";
   }
}
