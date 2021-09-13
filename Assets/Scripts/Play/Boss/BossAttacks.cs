using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public GameObject basicProjectile;

    private int projectilesToPool;

    private Boss boss;
    private List<GameObject> projectiles;

    private void Start()
    {
        boss = GetComponent<Boss>();

        // Basic Projectile data setup
        BasicProjectile basicProjData = basicProjectile.GetComponent<BasicProjectile>();
        basicProjData.speed = boss.bossData.bpSpeed;
        basicProjData.reloadRate = boss.bossData.bpReloadRate;

        // Object pooling setup --> Basic Projectiles
        projectiles = new List<GameObject>();
        projectilesToPool = boss.bossData.basicProjectiles;
        projectiles = ObjectPooler.CreateObjectPool(projectilesToPool, basicProjectile);
    }

    public void SingleFire()
    {
        GameObject projectile = ObjectPooler.GetPooledObject(projectiles);

        // If boss has projectiles available to fire
        if (projectile != null)
        
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.GetComponent<BasicProjectile>().dir = Vector3.forward;

            projectile.SetActive(true);
        
    }

    public void StartSingleFire()
    {
        InvokeRepeating("SingleFire", boss.bossData.bpStartTime, boss.bossData.bpFireRate);
    }

    public void StopSingleFire()
    {
        CancelInvoke();
    }
}
