using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Create a singleton pattern
    public static GameManager instance { get; private set; }

    // Check if 'gravity' is on or off
    public bool gravOn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravOn = !gravOn;
        }
    }
}
