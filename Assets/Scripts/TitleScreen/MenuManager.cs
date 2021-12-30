using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas howToPlayMenu;

    public AudioSource audioSource;

    private bool mainMenuActive;

    void Start()
    {
        // Main menu is active
        mainMenuActive = true;
    }

    public void ChangeMenus()
    {
        audioSource.Play();
        mainMenuActive = !mainMenuActive;
        mainMenu.gameObject.SetActive(mainMenuActive);
        howToPlayMenu.gameObject.SetActive(!mainMenuActive);
    }

    public void PlayGame()
    {
        // Load Play scene
        audioSource.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        audioSource.Play();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
