using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchpadManager : MonoBehaviour
{
    public List<LaunchpadMovement> launchpads;

    // List used to pick random launchpad(s)
    private List<int> randomNums;

    private void Start()
    {
        randomNums = new List<int>();        
    }

    public void ChangeLaunchpadsRaised()
    {
        StartCoroutine(WaitForBarriers());
    }

    // Raise Launchpads as barriers to the player's movement
    public void RaiseBarrierLaunchpads(int _amountToRaise)
    {
        List<int> barriersToRaise = new List<int>();

        barriersToRaise = GenerateRandom(_amountToRaise);

        foreach (int index in barriersToRaise)
        {
            launchpads[index].BarrierLaunchpad();
        }
    }  

    // Launchpads all retract back into the walls
    public void RetractAllLaunchpads()
    {
        foreach (var item in launchpads)
        {
            item.RetractLaunchpad();
        }
    }

    #region Helper Functions
    // Generate random num of launchpads to raise
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

    IEnumerator WaitForBarriers()
    {
        RetractAllLaunchpads();
        yield return new WaitForSeconds(6);
        RaiseBarrierLaunchpads(2);
    }
    #endregion
}
