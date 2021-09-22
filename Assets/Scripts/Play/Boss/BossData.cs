using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossData : MonoBehaviour
{
    #region Boss Health Data
    public int health;
    public int shieldHealthMax;
    public int shieldHealth;
    #endregion

    #region Sponge State Data
    public int basicProjectiles;

    public float bpStartTime;
    public float bpFireRate;
    public float bpDestroyAfter;
    public float bpSpeed;
    #endregion

    #region No Grav State Data
    public float areaFireRate;

    public float mineSpeed;
    public float mineDestroyAfter;
    public float mineStartTime;
    public List<Transform> mineLocations;
    #endregion
}
