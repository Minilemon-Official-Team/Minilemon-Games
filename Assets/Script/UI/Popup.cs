using UnityEngine;

/// <summary>
/// Class untuk mengatur popup, 1 popup pada satu waktu
/// </summary>
public class Popup : MonoBehaviour
{
    public static bool isOpened = false;
    
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Popup").Length > 0)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    /// <summary>
    /// Buka popup
    /// </summary>
    public static void Open()
    {
        if (isOpened) return;

        isOpened = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Tutup popup
    /// </summary>
    public static void Close()
    {
        if (!isOpened) return;

        isOpened = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
