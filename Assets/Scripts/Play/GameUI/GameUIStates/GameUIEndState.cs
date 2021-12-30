using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIEndState : BaseState
{
    private GameUI gameUI;

    public GameUIEndState(GameUI _gameUI)
    {
        gameUI = _gameUI;
    }

    public override void Enter()
    {
       // Show Game Over menu if player has died
       if (gameUI.player.playerData.health <= 0)
       {
            gameUI.gameOverMenu.gameObject.SetActive(true);
            gameUI.gameUISFX.gameUIAudioSource.PlayOneShot(gameUI.gameUISFX.gameUIAudio[2]);
        }
        // Show Win menu if player has won
        else
       {
            gameUI.winMenu.gameObject.SetActive(true);
            gameUI.gameUISFX.gameUIAudioSource.PlayOneShot(gameUI.gameUISFX.gameUIAudio[1]);
       }
    }
}
