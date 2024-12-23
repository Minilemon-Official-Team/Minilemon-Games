using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class yang digunakan di scene main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField, Tooltip("Object progress bar")]
    Image loadingBar;

    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadGame()
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("Scenes/Map1/Map1");

        while (!loadingOperation.isDone)
        {
            loadingBar.fillAmount = Mathf.Clamp01(loadingOperation.progress);
            yield return null;
        }
    }
}
