using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroSpongeState : BaseState
{
    private EnvironmentManager enviroManager;

    private float nextBarrierRaise;

    public EnviroSpongeState(EnvironmentManager _enviroManager)
    {
        enviroManager = _enviroManager;
    }

    public override void Enter()
    {
        // Reset timer
        nextBarrierRaise = 0;
    }

    public override void LogicUpdate()
    {
        // Time between next barrier raises
        if (Time.time > nextBarrierRaise)
        {
            nextBarrierRaise = Time.time + enviroManager.enviroData.barrierRate;
            enviroManager.launchpadManager.ActivateBarrierSequence(2);
        }
    }

    public override void Exit()
    {
        enviroManager.launchpadManager.RetractAllLaunchpads();
    }
}
