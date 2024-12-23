using TMPro;
using UnityEngine;

/// <summary>
/// Class untuk harta karun
/// </summary>
public class Treasure : Collectible
{
    [SerializeField, Tooltip("Canvas tulisan tombol")]
    GameObject display;

    [SerializeField, Tooltip("Butuh kunci atau tidak?")]
    bool needKey;

    [SerializeField, Tooltip("Item yang akan diambil")]
    TextMeshProUGUI keyWarning;

    [SerializeField]
    Animator anim;

    bool isOpened = false;

    void OnTriggerEnter(Collider other)
    {
        if (isOpened) return;
        if (other.CompareTag("Player"))
        {
            display.SetActive(true);

            if (Player.instance.inventory.keys > 0 || !needKey)
            {
                keyWarning.text = "Tekan E untuk buka";
            }
            else
            {
                keyWarning.text = "Cari kuncinya dulu ya";
            }
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
        
    }

    /// <summary>
    /// Interaksi dengan treasure
    /// </summary>
    public void Interact()
    {
        if (isOpened) return;

        if (!needKey) Open();
        else if (Player.instance.inventory.UseKey()) Open();
    }

    /// <summary>
    /// Buka treasure
    /// </summary>
    void Open()
    {
        EventBus.ItemCollected?.Invoke(item);
        display.SetActive(false);
        anim.SetBool("OpenChest", true);

        isOpened = true;
    }
}
