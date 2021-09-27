using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Exposed to the editor for easy designer access

    #region Player Health Data
    [Header("Health Data")]
    public int health;
    #endregion

    #region Movement Data
    [Header("Movement Data")]
    public float gravSpeed;
    public float noGravSpeed;
    public float launchSpeed;
    #endregion

    #region Projectile Data
    [Header("Projectile Data")]
    public float gravFireDestroyAfter;
    public float gravFireSpeed;

    public int gravProjectiles;
    #endregion
}
