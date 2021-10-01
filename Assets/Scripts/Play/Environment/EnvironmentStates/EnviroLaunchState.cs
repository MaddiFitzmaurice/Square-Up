using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroLaunchState : BaseState
{
    private EnvironmentManager enviro;

    public EnviroLaunchState(EnvironmentManager _enviro)
    {
        enviro = _enviro;
    }

    public override void Enter()
    {
        enviro.launchpadManager.ActivateLaunchSequence();
    }
}
