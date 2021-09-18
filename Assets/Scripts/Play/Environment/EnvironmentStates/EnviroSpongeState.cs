using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroSpongeState : BaseState
{
    private EnvironmentManager enviro;
    private LaunchpadDir launchpadDir;

    public EnviroSpongeState(EnvironmentManager _enviro)
    {
        enviro = _enviro;
    }

    public override void Enter()
    {
        enviro.launchPads[(int)LaunchpadDir.Floor].BarrierLaunchpad();
    }

    public override void LogicUpdate()
    {
        
    }

    public override void Exit()
    {
        // Launchpads must all retract back into the walls
        foreach (var item in enviro.launchPads)
        {
            item.RetractLaunchpad();
        }
    }
}
