using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    #region NoGravState Game Data
    [Header("NoGrav Boss Attacking Phase Times")]
    public int phaseOneTime;
    public int phaseTwoTime;
    public int phaseThreeTime;
    #endregion

    #region AttackState Game Data
    public int launchpadCountdown;
    #endregion

    #region State Timers
    [Header("State Fail Timers")]
    public float spongeStateFailedTime;
    public float attackStateFailedTime;
    #endregion
}
