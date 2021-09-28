using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossData : MonoBehaviour
{
    #region Boss Health Data
    [Header("Health Data")]
    public int health;
    public int healthMax;
    public int shieldHealthMax;
    public int shieldHealth;
    #endregion

    #region Single Fire Data
    [Header("Single Fire Data")]
    public int singleFireProjectiles;
    public int singleFireDamage;
    public float singleFireSpeed;
    public float singleFireDestroyAfter;
    public float singleFireStartTime;
    public float singleFireRate;
    #endregion

    #region Area Fire Data
    [Header("Area Fire Data")]
    public int areaFireProjectiles;
    public int numOfDirections;
    public int areaFireDamage;
    public float areaFireSpeed;
    public float areaFireRate;
    public float areaFireDestroyAfter;
    public float areaFireStartTime;
    public float angularVelocity;

    [Header("Mine Field Data")]
    public int mineDamage;
    public float mineSpeed;
    public float mineDestroyAfter;
    public float mineStartTime;
    public List<Transform> mineLocations;

    [Header("Tracking Fire Data")]
    public int trackerDamage;
    public float trackerSpeed;
    public float trackerDestroyAfter;
    public float trackerStartTime;
    #endregion
}
