using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Create a singleton pattern
    public static GameManager gameManager { get; private set; }

    // Check if 'gravity' is on or off
    public bool gravOn;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Start()
    {
        gravOn = true;
    }
}
