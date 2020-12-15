using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    PlayerItems playerItems;
    public Item item {get; private set;}
    public Image image;

    void Start()
    {
        playerItems = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
    }

    // Start is called before the first frame update
    public void SetItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
        image.enabled = true;
    }

    public void RemoveItem()
    {
        playerItems.AddItem(item);
        item = null;
        image.sprite = null;
        image.enabled = false;
    }



}
