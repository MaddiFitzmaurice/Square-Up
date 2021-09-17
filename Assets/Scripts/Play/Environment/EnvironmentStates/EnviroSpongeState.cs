using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroSpongeState : BaseState
{
    private EnvironmentManager enviro;
    private List<GameObject> launchpads;

    public EnviroSpongeState(EnvironmentManager _enviro, List<GameObject> _launchpads)
    {
        enviro = _enviro;
        launchpads = _launchpads;
    }

    public override void Enter()
    {
        launchpads[0].GetComponent<LaunchpadMovement>().BarrierLaunchpad();
    }
}
