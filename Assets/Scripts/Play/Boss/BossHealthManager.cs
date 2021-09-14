using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    public GameObject shield;

    private Boss boss;
    private SphereCollider shieldCollider;

    private void Start()
    {
        boss = GetComponent<Boss>();
        shieldCollider = GetComponent<SphereCollider>();
        boss.bossData.shieldHealth = boss.bossData.shieldHealthMax;
    }

    // Handling attacks from the player
    private void OnTriggerEnter(Collider other)
    {
        // Attacked during Sponge State
        if (other.CompareTag("PlayerProjectile"))
        {
            if (shield.activeInHierarchy)
            {
                boss.bossData.shieldHealth -= 1;
                other.gameObject.SetActive(false);

                if (boss.bossData.shieldHealth == 0)
                {
                    shield.SetActive(false);
                    shieldCollider.enabled = false;
                }
            }
        }
    }

    public void ResetShields()
    {
        boss.bossData.shieldHealth = boss.bossData.shieldHealthMax;
        shield.SetActive(true);
        shieldCollider.enabled = true;
    }
}
