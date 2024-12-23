using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class untuk item
/// </summary>
[System.Serializable]
public class Item
{
    /// <summary>
    /// Data dari item
    /// </summary>
    [Tooltip("Data dari item, letaknya di Assets/Resources/Items")]
    public ItemData data;
    
    /// <summary>
    /// Jumlah item
    /// </summary>
    [Tooltip("Jumlah item"), Min(1)]
    public int amount;
}
