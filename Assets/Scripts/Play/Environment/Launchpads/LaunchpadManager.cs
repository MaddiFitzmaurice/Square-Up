using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchpadManager : MonoBehaviour
{
    public List<LaunchpadMovement> launchpads;

    private int numOfBarriers;

    // Lists used to pick random launchpads and store them
    private List<int> randomNums;
    private List<int> barriersToRaise;
    private List<int> launchpadSelection;

    private void Start()
    {
        randomNums = new List<int>();
        barriersToRaise = new List<int>();
        launchpadSelection = new List<int>();
    }

    #region AttackState Functions

    public void InitiateLaunch()
    {
        launchpadSelection.Clear();
        launchpadSelection = GenerateRandom(1);
        // Activate launch trigger box
        launchpads[launchpadSelection[0]].launchTrigger.enabled = true;
        Debug.Log(launchpadSelection[0]);
    }

    public void Launch()
    {
        launchpads[launchpadSelection[0]].LaunchLaunchpad();
    }
    #endregion

    #region SpongeState Functions
    // Accessed by Sponge State
    // Number of barriers to raise increases with each cycle
    public void ActivateBarrierLaunchpads(int _numOfBarriers)
    {
        numOfBarriers = _numOfBarriers;
        StartCoroutine(BarrierSequence());
    }

    // Chain together functions to operate sequentially
    IEnumerator BarrierSequence()
    {
        StartCoroutine(LowerBarriers());
        StartCoroutine(RaiseBarriers());
        yield break;
    }

    // Lower barriers and return when all have retracted completely
    IEnumerator LowerBarriers()
    {
        foreach (var item in launchpads)
        {
            item.RetractLaunchpad();
        }

        while (!CheckIfRetractedAll())
        {
            yield return null;
        }
        
        yield break;
    }

    // Raise Launchpads as barriers to the player's movement
    IEnumerator RaiseBarriers()
    {
        RaiseBarrierLaunchpads(numOfBarriers);
        yield break;
    }

    // Select random launchpads and raise them to act as barriers
    public void RaiseBarrierLaunchpads(int _amountToRaise)
    {
        barriersToRaise.Clear();
        barriersToRaise = GenerateRandom(_amountToRaise);

        foreach (int index in barriersToRaise)
        {
            launchpads[index].BarrierLaunchpad();
        }
    }  

    // Launchpads all retract back into the walls
    // when exiting Sponge State
    public void RetractAllLaunchpads()
    {
        StopAllCoroutines();
        foreach (var item in launchpads)
        {
            item.RetractLaunchpad();
        }
    }
    #endregion

    #region Helper Functions
    // Pick random launchpad(s) to turn into barriers or launcher
    private List<int> GenerateRandom(int _amount)
    {
        randomNums.Clear();
        int randomNum = Random.Range(0, launchpads.Count);
        randomNums.Add(randomNum);

        if (_amount == 1)
        {
            return randomNums;
        }
        else
        {
            while (randomNums.Count < _amount)
            {
                randomNum = Random.Range(0, launchpads.Count);

                if (!randomNums.Contains(randomNum))
                {
                    randomNums.Add(randomNum);
                }
            }
        }
        return randomNums;
    }

    // Check if all barriers are retracted into the wall
    private bool CheckIfRetractedAll()
    {
        foreach (var item in launchpads)
        {
            if (item.raised)
            {
                return false;
            }
        }
        return true;
    }
    #endregion
}
