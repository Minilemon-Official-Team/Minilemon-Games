using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class untuk slot/elemen pada inventory
/// </summary>
public class InventorySlot : MonoBehaviour
{
    /// <summary>
    /// Index dari slot
    /// </summary>
    [HideInInspector] public int index;
    
    /// <summary>
    /// Item yang ada pada slot
    /// </summary>
    [HideInInspector] public Item item;

    /// <summary>
    /// Object yang menampilkan icon
    /// </summary>
    [SerializeField, Tooltip("Object yang menampilkan icon")]
    Image icon;
    
    /// <summary>
    /// Object yang menampilkan jumlah item
    /// </summary>
    [SerializeField, Tooltip("Object yang menampilkan jumlah item")]
    TextMeshProUGUI amount;

    void Start()
    {
        icon.sprite = item.data.icon;
        amount.text = item.amount == 1 ? "" : item.amount.ToString();
    }

    void Update()
    {

    }

    /// <summary>
    /// Pilih item, kemudian buat player memegang item tersebut
    /// </summary>
    public void Selected()
    {
        InventoryUI.instance.Toggle();

        Player.instance.SetHand(item);
        Player.instance.inventory.selectedIndex = index;
    }
}
