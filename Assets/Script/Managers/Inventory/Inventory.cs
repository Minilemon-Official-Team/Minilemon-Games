using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class untuk inventory player
/// </summary>
public class Inventory
{
    /// <summary>
    /// List item yang ada di inventory
    /// </summary>
    public List<Item> mainItems { get; private set; }
    
    /// <summary>
    /// Banyak kunci untuk membuka treasure
    /// </summary>
    public int keys { get; private set; }

    /// <summary>
    /// Index item yang sedang dipilih
    /// </summary>
    public int selectedIndex;

    public Inventory()
    {
        mainItems = new List<Item>(25);
    }

    /// <summary>
    /// Menambahkan item ke inventory
    /// </summary>
    /// <param name="item">Item yang ingin ditambahkan</param>
    public void AddItem(Item item)
    {
        ItemData data = item.data;
        int amount = item.amount;

        // Cek apakah item sudah ada di inventory, jika ya tambahkan jumlahnya
        foreach (Item i in mainItems)
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

        // Jika item belum ada di inventory
        while (amount > 0 && mainItems.Count < mainItems.Capacity)
        {
            int toAdd = Mathf.Min(amount, data.maxStack);
            mainItems.Add(new Item { data = data, amount = toAdd });
            amount -= toAdd;
        }

        InventoryUI.instance.Refresh();
    }

    /// <summary>
    /// Menghapus item pada index tertentu
    /// </summary>
    /// <param name="index">Letak index item yang ingin dibuang</param>
    public void RemoveItemAt(int index)
    {
        mainItems.RemoveAt(index);

        InventoryUI.instance.Refresh();
    }

    /// <summary>
    /// Menambahkan kunci
    /// </summary>
    public void AddKey() => keys++;
    
    /// <summary>
    /// Menggunakan kunci
    /// </summary>
    /// <returns></returns>
    public bool UseKey()
    {
        if (keys > 0) 
        {
            keys--;
            return true;
        }
        return false;
    }
}
