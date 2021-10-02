using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroLaunchState : BaseState
{
    private EnvironmentManager enviroManager;

    public EnviroLaunchState(EnvironmentManager _enviroManager)
    {
        enviroManager = _enviroManager;
    }

    public override void Enter()
    {
        // Change colour of background launchpad to signal to player that it is friendly
        enviroManager.launchpadManager.ActivateLaunchSequence();
    }

    public override void Exit()
    {
        // Change colour of launchpad back to Boss colour
        enviroManager.launchpadManager.launchpads[0].GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
    }
}
