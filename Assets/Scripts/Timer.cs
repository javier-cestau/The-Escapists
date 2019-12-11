using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.LWRP;

public class Timer : MonoBehaviour
{
    Text timeText;
    Text dayText;

    public Light2D globalight;

    int hours;
    float minutes;
    float intensityMultiplier = 1f;
    float minIntensity = .6f;
    float maxIntensity = 1f;

    int currentDay = 1;

    // Start is called before the first frame update
    void Start()
    {
        hours = 23;
        minutes = 50;
        intensityMultiplier = 1f;
        timeText = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        dayText = GameObject.FindGameObjectWithTag("Day").GetComponent<Text>();
        dayText.text = currentDay.ToString();
    }

    void FixedUpdate()
    {
        minutes += Time.deltaTime * 90;
        if(Mathf.Floor(minutes) >= 60 ) {
            if(hours == 23) {
                currentDay++;
                dayText.text = currentDay.ToString();
                hours = 0;
            } else {
                hours++;
            }

            minutes = 0;
        }

        SetIntensity();
        timeText.text = hours.ToString().PadLeft(2, '0') + ":" + Mathf.Floor(minutes).ToString().PadLeft(2, '0');
    }

    void SetIntensity() {
        // float seconds = (hours * 60 * 60) + (minutes * 60);
        if(hours >= 0 && hours <= 12) {
            intensityMultiplier = Mathf.InverseLerp(0, 12, hours);
            globalight.intensity = Mathf.Lerp(minIntensity, maxIntensity, intensityMultiplier);
        } else {
            intensityMultiplier = Mathf.InverseLerp(12, 23, hours);
            globalight.intensity = Mathf.Lerp(maxIntensity, minIntensity, intensityMultiplier);
        }
    }
}
