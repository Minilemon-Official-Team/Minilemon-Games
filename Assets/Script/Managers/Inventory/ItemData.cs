using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class untuk data item
/// </summary>
[CreateAssetMenu(fileName = "ItemData", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    /// <summary>
    /// Nama item
    /// </summary>
    [field: SerializeField, Tooltip("Nama item")]
    public string itemName { get; private set; }

    /// <summary>
    /// Icon item untuk ditampilkan di inventory
    /// </summary>
    [field: SerializeField, Tooltip("Icon item untuk ditampilkan di inventory")]
    public Sprite icon { get; private set; }

    /// <summary>
    /// Banyaknya maksimal item yang bisa distack dalam 1 slot
    /// </summary>
    [field: SerializeField, Tooltip("Banyaknya maksimal item yang bisa distack dalam 1 slot"), Min(1)]
    public int maxStack { get; private set; } = 1;

    /// <summary>
    /// Prefab untuk item
    /// </summary>
    [field: SerializeField, Tooltip("Prefab untuk item")]
    public GameObject prefab { get; private set; }

}
