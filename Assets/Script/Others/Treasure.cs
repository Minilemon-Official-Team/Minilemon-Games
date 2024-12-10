using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Collectible
{
    [SerializeField, Tooltip("Canvas tulisan tombol")]
    GameObject display;

    [SerializeField, Tooltip("Butuh kunci atau tidak?")]
    bool needKey;

    [SerializeField]
    Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            display.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            display.SetActive(false);
        }
    }

    public override void Pick()
    {
        if (!needKey)
        {
            EventBus.InvokeItemCollected(item);
            anim.SetBool("OpenChest", true);
        }
        else
        {
            if (Player.instance.inventory.UseKey())
            {
                EventBus.InvokeItemCollected(item);
                anim.SetBool("OpenChest", true);
            }
        }
    }
}
