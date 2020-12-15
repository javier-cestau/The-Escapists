using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool
{
    public static List<Item> pool = new List<Item>();

    public static void AddItemToPool(Item item) {
        pool.Add(item);
    }

    public static List<Item> GrabAllItems() {
        List<Item> newList = new List<Item>(pool);
        pool.Clear();
        return newList;
    }
}
