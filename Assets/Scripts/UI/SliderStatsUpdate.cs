using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderStatsUpdate : MonoBehaviour
{
    Slider slider;
    public string attributeName;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void FixedUpdate()
    {
        if(PlayerManager.instance.currentPlayerData != null) {
            slider.value = (int) typeof(CharacterData).GetField(attributeName).GetValue(PlayerManager.instance.currentPlayerData);
        }
    }
}
