using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> mainItems { get; private set; }

    public Inventory()
    {
        mainItems = new List<Item>(25);
    }

    public void AddItem(Item item)
    {
        ItemData data = item.data;
        int amount = item.amount;
        foreach (var i in mainItems)
        {
            if (i.data == data && i.amount < data.maxStack)
            {
                i.amount += amount;
                if (i.amount > data.maxStack)
                {
                    amount = i.amount - data.maxStack;
                    i.amount = data.maxStack;
                }
                else
                {
                    return;
                }
            }
        }
        if (mainItems.Count < mainItems.Capacity)
        {
            while (amount > 0)
            {
                int toAdd = Mathf.Min(amount, data.maxStack);
                mainItems.Add(new Item { data = data, amount = toAdd });
                amount -= toAdd;
            }
        }
        Debug.Log(mainItems.Count);
    }
}
