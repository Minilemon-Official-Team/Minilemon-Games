using UnityEngine;

public static class Popup
{
    public static void Open()
    {
        if (isOpened) return;

        isOpened = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public static void Close()
    {
        if (!isOpened) return;

        isOpened = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static bool isOpened = false;
}
