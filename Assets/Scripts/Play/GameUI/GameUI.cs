using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameUI : MonoBehaviour
{
    // GameUI's state machine
    public StateMachine stateMachine;

    // GameUI's states
    public GameUIStartState gameUIStartState;
    public GameUIPlayState gameUIPlayState;
    public GameUIEndState gameUIEndState;

    // GameUI's components
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject winMenu;

    // Reference to player
    public Player player;
    
    private void Awake()
    {
        // Create GameUI's states
        gameUIStartState = new GameUIStartState(this);
        gameUIPlayState = new GameUIPlayState(this);
        gameUIEndState = new GameUIEndState(this);

        // Create GameUI's state machine
        stateMachine = new StateMachine(gameUIStartState);

        // Get reference to player
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {

    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
