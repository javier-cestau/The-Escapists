using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStatsDrawer : MonoBehaviour
{
    TextMeshProUGUI moneyText, healthText, heatText, enduranceText;

    const string PERCENT = "%";

    CharacterData playerData;

    void Awake()
    {
        playerData = PlayerManager.instance.currentPlayerData;
        foreach (GameObject stat in GameObject.FindGameObjectsWithTag("Stats"))
        {
            switch (stat.name)
            {
                case "MoneyValue":
                    moneyText = stat.GetComponent<TextMeshProUGUI>();
                    break;
                case "HealthValue":
                    healthText = stat.GetComponent<TextMeshProUGUI>();
                    break;
                case "HeatValue":
                    heatText = stat.GetComponent<TextMeshProUGUI>();
                    break;
                case "EnduranceValue":
                    enduranceText = stat.GetComponent<TextMeshProUGUI>();
                    break;
            }
        }

    }

    void OnGUI()
    {
        if(moneyText.text != playerData.money.ToString()) {
            moneyText.text = playerData.money.ToString();
        }

        if(healthText.text != playerData.health.ToString()) {
            healthText.text = playerData.health.ToString();
        }

        if(heatText.text != playerData.heat.ToString()) {
            heatText.text = playerData.heat.ToString() + PERCENT;
        }

        if(enduranceText.text != playerData.endurance.ToString()) {
            enduranceText.text = playerData.endurance.ToString() + PERCENT;
        }


    }
}
