using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Item item;

    public void Pick()
    {
        Player.instance.inventory.AddItem(item);
        Destroy(gameObject);
    }
}
