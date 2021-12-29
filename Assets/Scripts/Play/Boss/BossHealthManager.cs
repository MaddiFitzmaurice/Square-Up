using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    public GameObject shield;
    public BoxCollider weakHitbox;

    private Boss boss;
    private SphereCollider shieldCollider;

    private void Start()
    {
        boss = GetComponent<Boss>();
        shieldCollider = GetComponent<SphereCollider>();
        boss.bossData.shieldHealth = boss.bossData.shieldHealthMax;
        boss.bossData.health = boss.bossData.healthMax;
        weakHitbox.enabled = false;
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
                    boss.bossSFX.bossAudioSource.PlayOneShot(boss.bossSFX.bossAudio[3]);
                    shieldCollider.enabled = false;
                }
            }
        }

        // Attacked during Weak State
        if (other.CompareTag("Player"))
        {
            if (weakHitbox.enabled)
            {
                boss.bossSFX.bossAudioSource.PlayOneShot(boss.bossSFX.bossAudio[0]);
                boss.bossData.health -= 1;
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
