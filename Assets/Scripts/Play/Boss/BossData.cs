using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossData : MonoBehaviour
{
    #region Boss Health Data
    [Header("Health Data")]
    public int health;
    public int shieldHealthMax;
    public int shieldHealth;
    #endregion

    #region Sponge State Data
    [Header("Basic Projectile Data")]
    public int basicProjectiles;

    public float bpStartTime;
    public float bpFireRate;
    public float bpDestroyAfter;
    public float bpSpeed;
    #endregion

    #region No Grav State Data
    [Header("Area Fire Data")]
    public float areaFireRate;

    [Header("Mine Field Data")]
    public float mineSpeed;
    public float mineDestroyAfter;
    public float mineStartTime;
    public List<Transform> mineLocations;

    [Header("Tracking Fire Data")]
    public float trackerSpeed;
    public float trackerDestroyAfter;
    public float trackerStartTime;
    #endregion
}
