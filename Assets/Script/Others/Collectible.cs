using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Item item;

    /// <summary>
    /// Ambil collectible
    /// </summary>
    public virtual void Pick()
    {
        EventBus.ItemCollected?.Invoke(item);
        
        Player.instance.inventory.AddItem(item);
        Destroy(gameObject);
    }
}
