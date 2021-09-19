using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroSpongeState : BaseState
{
    private EnvironmentManager enviro;
    private LaunchpadDir launchpadDir;

    private float nextBarrierRaise;

    public EnviroSpongeState(EnvironmentManager _enviro)
    {
        enviro = _enviro;
    }

    public override void Enter()
    {
        nextBarrierRaise = 0;
    }

    public override void LogicUpdate()
    {
        // Time between next barrier raises
        if (Time.time > nextBarrierRaise)
        {
            nextBarrierRaise = Time.time + enviro.enviroData.barrierRate;
            enviro.launchpadManager.ChangeLaunchpadsRaised();
        }
    }

    public override void Exit()
    {
        enviro.launchpadManager.RetractAllLaunchpads();
    }
}
