using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas howToPlayMenu;

    private bool mainMenuActive;

    void Start()
    {
        // Main menu is active
        mainMenuActive = true;
    }

    public void ChangeMenus()
    {
        mainMenuActive = !mainMenuActive;
        mainMenu.gameObject.SetActive(mainMenuActive);
        howToPlayMenu.gameObject.SetActive(!mainMenuActive);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
