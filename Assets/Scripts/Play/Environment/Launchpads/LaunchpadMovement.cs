using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchpadMovement : MonoBehaviour
{
    // Movement constrictions
    private float upperBound = 14.3f;
    private float lowerBound = 13.3f;

    void Start()
    {
        
    }

    // Launchpad comes out of wall to act as barrier for player
    public void BarrierLaunchpad()
    {
        StartCoroutine(MoveOut());
    }

    // Launchpad retracts inside wall
    public void RetractLaunchpad()
    {
        StartCoroutine(MoveIn());
    }

    IEnumerator MoveOut()
    {
        yield return null;
    }

    IEnumerator MoveIn()
    {
        yield return null;
    }
}
