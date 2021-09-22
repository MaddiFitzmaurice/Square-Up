using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Exposed to the editor for easy designer access

    #region Player Health Data
    public int health;
    #endregion

    #region Gravity Data
    public float gravSpeed;
    public float gravFireDestroyAfter;
    public float gravFireSpeed;

    public int gravProjectiles;
    #endregion

    #region No Gravity Data
    public float noGravSpeed;
    #endregion
}
