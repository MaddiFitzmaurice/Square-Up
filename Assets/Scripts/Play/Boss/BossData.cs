using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossData : MonoBehaviour
{
    #region Boss Health Data
    public int health;
    public int shieldHealth;
    #endregion

    #region Sponge State Data
    public int basicProjectiles;

    public float bpStartTime;
    public float bpFireRate;
    public float bpReloadRate;
    public float bpSpeed;
    #endregion
}
