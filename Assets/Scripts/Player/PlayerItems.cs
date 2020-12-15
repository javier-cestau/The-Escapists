using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    Image[] slotItems;
    CharacterData playerData;

    AudioSource source { get { return GameObject.FindGameObjectWithTag("SFXSounds").GetComponent<AudioSource>(); } }

    public AudioClip grabbingSound;

    void Awake()
    {
        slotItems = new Image[6];
        playerData = GetComponent<CharacterContainer>().characterData;
        playerData.inventory = new Item[6];
        int index = 0;
        foreach (var gameObject in GameObject.FindGameObjectsWithTag("SlotItem"))
        {
            slotItems[index] = gameObject.GetComponent<Image>();
            slotItems[index].enabled = false;
            ItemSlot itemSlot = slotItems[index].gameObject.AddComponent<ItemSlot>();
            itemSlot.index = index;
            index++;
        }
    }

    public bool AddItem(Item newItem)
    {
        int firstEmptyIndex = System.Array.IndexOf(playerData.inventory, null);
        if(firstEmptyIndex != -1) {
            playerData.inventory[firstEmptyIndex] = newItem;
            slotItems[firstEmptyIndex].sprite = newItem.icon;
            slotItems[firstEmptyIndex].enabled = true;
            slotItems[firstEmptyIndex].GetComponent<Animator>().Play("ItemScale", -1, 0);
            source.PlayOneShot(grabbingSound);
            return true;
        }
        return false;
    }

    public void DropItem(int index) {
        ItemPool.AddItemToPool(playerData.inventory[index]);
        playerData.inventory[index] = null;
        slotItems[index].enabled = false;
    }

}
