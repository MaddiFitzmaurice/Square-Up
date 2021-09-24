using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    #region No Grav State Game Data
    [Header("No Grav Boss Attacking Phase Times")]
    public int phaseOneTime;
    public int phaseTwoTime;
    public int phaseThreeTime;
    #endregion

    #region State Timers
    [Header("State Fail Timers")]
    public float spongeStateFailedTime;
    public float attackStateFailedTime;
    #endregion
}
