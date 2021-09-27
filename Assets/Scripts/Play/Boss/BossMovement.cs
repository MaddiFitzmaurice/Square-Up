using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Boss boss;

    private Vector3 vectorSpeed;

    private void Start()
    {
        boss = GetComponent<Boss>();
        vectorSpeed = new Vector3(0, boss.bossData.angularVelocity, 0);
    }

    public void LookAtPlayer()
    {
        Vector3 lookDir = boss.player.transform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookDir, Vector3.up);
        boss.bossRb.MoveRotation(lookRot);
    }

    public void SpinAround()
    {
        Quaternion deltaRotation = Quaternion.Euler(vectorSpeed * Time.fixedDeltaTime);
        boss.bossRb.MoveRotation(boss.bossRb.rotation * deltaRotation);
    }

    // Reset Boss's rotation
    public void ResetRotation()
    {
        StartCoroutine(ResettingRotation());
    }

    // Coroutine to reset Boss rotation
    IEnumerator ResettingRotation()
    {
        while (Quaternion.Angle(boss.bossRb.rotation, Quaternion.identity) > 0.5f)
        {
            Quaternion deltaRotation = Quaternion.Euler(vectorSpeed * Time.fixedDeltaTime);
            boss.bossRb.MoveRotation(boss.bossRb.rotation * deltaRotation);
            yield return null;
        }
    }

    

    
}
