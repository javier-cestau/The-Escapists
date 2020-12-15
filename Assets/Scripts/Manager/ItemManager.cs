using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    GameObject player;
    CraftSlot[] craftSlots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

     void Update()
    {
        if(Time.timeScale == 1 && ItemPool.pool.Count > 0) {
            foreach (Item item in ItemPool.GrabAllItems())
            {
                GameObject itemInstance = GameObject.Instantiate(Resources.Load("Prefabs/Item", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject;
                itemInstance.GetComponent<ItemCollectable>().item = item;
                itemInstance.SetActive(true);
            }
        } else if(GameManager.instance.currentOpenMenuWindow != null && ItemPool.pool.Count > 0) {
            if(GameManager.instance.currentOpenMenuWindow.name == "CraftingPanel") {
                if(craftSlots == null) {
                    craftSlots = GameObject.Find("CraftSlots").GetComponentsInChildren<CraftSlot>();
                }

                foreach (Item item in ItemPool.GrabAllItems())
                {
                    foreach (CraftSlot craftSlot in craftSlots)
                    {
                        if(craftSlot.item == null) {
                            craftSlot.SetItem(item);
                            break;
                        }
                    }
                }
            }
        }
    }
}
