using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchpadManager : MonoBehaviour
{
    public List<LaunchpadMovement> launchpads;
    public List<LaunchpadMovement> launchpadsBG;

    private int numOfBarriers;

    private EnvironmentManager enviroManager;

    // Lists used to pick random launchpads and store them
    private List<int> randomNums;
    private List<int> barriersToRaise;
    private List<int> launchpadSelection;

    private void Start()
    {
        enviroManager = GetComponent<EnvironmentManager>();   
        randomNums = new List<int>();
        barriersToRaise = new List<int>();
        launchpadSelection = new List<int>();
    }

    #region AttackState Functions

    public void ActivateLaunchSequence()
    {
        StartCoroutine(LaunchSequence());
    }

    IEnumerator LaunchSequence()
    {
        // Clear previously chosen launchpad and pick new one
        StartCoroutine(LowerBarriers(launchpadsBG));
        yield return new WaitForSeconds(1);
        StartCoroutine(LowerBarriers(launchpads));
        yield return new WaitForSeconds(2);
        // Change colour to green to signal to player the launchpads are friendly
        launchpads[0].GetComponent<MeshRenderer>().sharedMaterial.color = enviroManager.enviroData.launchColour;
        launchpadSelection.Clear();
        launchpadSelection = GenerateRandom(1);
        // Raise background barrier to indicate which launchpad is active
        launchpadsBG[launchpadSelection[0]].BarrierLaunchpad();
        launchpads[launchpadSelection[0]].launchTrigger.enabled = true;
        yield break;
    }

    public void Launch()
    {
        StartCoroutine(LowerBarriers(launchpadsBG));
        launchpads[launchpadSelection[0]].LaunchLaunchpad();
    }
    #endregion

    #region SpongeState Functions
    // Accessed by Sponge State to start barrier sequence
    // Number of barriers to raise increases with each cycle
    public void ActivateBarrierSequence(int _numOfBarriers)
    {
        numOfBarriers = _numOfBarriers;
        StartCoroutine(BarrierSequence());
    }

    // Chain together functions to operate sequentially
    IEnumerator BarrierSequence()
    {
        // Clear previously chosen barriers and pick x new ones to raise
        barriersToRaise.Clear();
        barriersToRaise = GenerateRandom(numOfBarriers);
        // Lower background barriers, then foreground barriers
        StartCoroutine(LowerBarriers(launchpadsBG));
        yield return new WaitForSeconds(2);
        StartCoroutine(LowerBarriers(launchpads));
        yield return new WaitForSeconds(1);
        // Raise background barriers, then foreground barriers
        StartCoroutine(RaiseBarriers(launchpadsBG));
        yield return new WaitForSeconds(2);
        StartCoroutine(RaiseBarriers(launchpads));
        yield break;
    }

    // Lower barriers and return when all have retracted completely
    IEnumerator LowerBarriers(List<LaunchpadMovement> _barriers)
    {
        foreach (var item in _barriers)
        {
            item.RetractLaunchpad();
        }

        while (!CheckIfRetractedAll(_barriers))
        {
            yield return null;
        }
        
        yield break;
    }

    // Raise foreground launchpads as barriers to the player's movement or
    // raise identical background barriers to indicate to player
    // which foreground ones will rise next
    IEnumerator RaiseBarriers(List<LaunchpadMovement> _barriers)
    {
        foreach (int index in barriersToRaise)
        {
            _barriers[index].BarrierLaunchpad();
        }

        yield break;
    }

    // Launchpads all retract back into the walls
    // Accessed when exiting Sponge State
    public void RetractAllLaunchpads()
    {
        StopAllCoroutines();
        foreach (var item in launchpads)
        {
            item.RetractLaunchpad();
        }

        foreach (var item in launchpadsBG)
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
    private bool CheckIfRetractedAll(List<LaunchpadMovement> _barriers)
    {
        foreach (var item in _barriers)
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
