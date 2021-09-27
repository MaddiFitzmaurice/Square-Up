using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroEvadeState : BaseState
{
    private EnvironmentManager enviro;

    public EnviroEvadeState(EnvironmentManager _enviro)
    {
        enviro = _enviro;
    }

    public override void Enter()
    {
        enviro.launchpadManager.RetractAllLaunchpads();
    }
}
