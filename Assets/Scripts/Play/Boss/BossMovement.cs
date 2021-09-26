using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Boss boss;

    private void Start()
    {
        boss = GetComponent<Boss>();
    }

    public void LookAtPlayer()
    {
        Vector3 lookDir = boss.player.transform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookDir, Vector3.up);
        boss.bossRb.MoveRotation(lookRot);
    }

    public void SpinAround()
    {
        Vector3 vectorSpeed = new Vector3(0, boss.bossData.angularVelocity, 0);
        Quaternion deltaRotation = Quaternion.Euler(vectorSpeed * Time.fixedDeltaTime);
        boss.bossRb.MoveRotation(boss.bossRb.rotation * deltaRotation);
    }

    public void ResetRotation()
    {
        
    }

    

    
}
