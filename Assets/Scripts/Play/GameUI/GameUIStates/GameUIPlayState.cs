using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIPlayState : BaseState
{
    private GameUI gameUI;
    private GameObject pauseMenu;

    private bool paused = false;

    public GameUIPlayState(GameUI _gameUI)
    {
        gameUI = _gameUI;
    }

    public override void LogicUpdate()
    {
        // Pause or unpause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            gameUI.pauseMenu.gameObject.SetActive(paused);

            if (paused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
