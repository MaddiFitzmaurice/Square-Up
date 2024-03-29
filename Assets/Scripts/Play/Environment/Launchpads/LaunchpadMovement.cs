﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchpadMovement : MonoBehaviour
{
    // Movement constrictions
    public Transform target;
    public Transform returnTarget;

    // Player Interaction Trigger Box
    public BoxCollider launchTrigger;

    // Raised flag
    public bool raised = false;
    public bool isBG;

    private void Start()
    {
        // Deactivate trigger box at beginning of game if foreground launchpad
        if (!isBG)
        {
            launchTrigger.enabled = false;
        }
    }

    #region SpongeState Functions
    // Launchpad comes out of wall to act as barrier for player
    public void BarrierLaunchpad()
    {
        // Activate trigger to detect whether player is on top
        // of foreground launchpad while it rises
        if (!isBG)
        {
            launchTrigger.enabled = true;
        }
        StopAllCoroutines();
        StartCoroutine(Move(target));
    }

    // Launchpad retracts inside wall
    public void RetractLaunchpad()
    {
        StopAllCoroutines();
        StartCoroutine(Move(returnTarget));
    }

    // Move barrier depending on target position
    IEnumerator Move(Transform _target)
    {
        while (Vector3.Distance(transform.position, _target.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        if (!isBG)
        {
            launchTrigger.enabled = false;
        }

        if (transform.position == target.position)
        {
            raised = true;
        }

        else if (transform.position == returnTarget.position)
        {
            raised = false;
        }
    }
    #endregion

    #region AttackState Functions
    // Launch Movement
    IEnumerator Launch()
    {
        while (Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 15);

            yield return new WaitForEndOfFrame();
        }

        while (Vector3.Distance(transform.position, returnTarget.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, returnTarget.position, Time.deltaTime * 15);

            yield return new WaitForEndOfFrame();
        }

        if (!isBG)
        {
            launchTrigger.enabled = false;
        }
    }

    public void LaunchLaunchpad()
    {
        StartCoroutine(Launch());
    }
    #endregion
}