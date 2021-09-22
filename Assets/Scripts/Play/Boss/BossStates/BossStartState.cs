using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartState : BaseState
{
    private Boss boss;
    public BossStartState(Boss _boss)
    {
        boss = _boss;
    }
}
