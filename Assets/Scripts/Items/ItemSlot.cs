using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerDownHandler
{
    public int index;

    PlayerItems playerItems;

    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerItems = player.GetComponent<PlayerItems>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Time.timeScale == 1 && eventData.button == PointerEventData.InputButton.Right) {
            playerItems.DropItem(index);
        } else if (GameManager.instance.currentOpenMenuWindow.name == "CraftingPanel" && eventData.button == PointerEventData.InputButton.Left) {
            playerItems.DropItem(index);
        }

    }

}
