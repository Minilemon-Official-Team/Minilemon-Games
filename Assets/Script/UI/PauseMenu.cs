using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputAction action;
    bool pauseShown = false;

    void Start()
    {
        transform.localScale = Vector3.zero;

        action.Enable();
        action.performed += _ => Pause();
    }

    public void Pause()
    {
        pauseShown = true;
        Time.timeScale = 0;
        transform.localScale = Vector3.one;
    }

    public void ResumeGame()
    {
        pauseShown = false;
        Time.timeScale = 1;
        transform.localScale = Vector3.zero;
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/MainMenu/MainMenu");
    }
}
