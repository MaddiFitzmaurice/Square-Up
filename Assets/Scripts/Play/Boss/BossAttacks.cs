using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public GameObject basicProjectile;
    public Transform basicProjectileGrouping;

    private int projectilesToPool;

    private Boss boss;
    private List<GameObject> projectiles;

    private void Start()
    {
        boss = GetComponent<Boss>();

        SingleFirePoolingSetup();
    }

    public void SingleFire()
    {
        GameObject projectile = ObjectPooler.GetPooledObject(projectiles);

        // If boss has projectiles available to fire
        if (projectile != null)
        {
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.GetComponent<BasicProjectile>().dir = Vector3.forward;
            projectile.SetActive(true);
        }
    }

    // ******Repurpose this into a general start attack that takes a string method name
    public void StartSingleFire()
    {
        InvokeRepeating("SingleFire", boss.bossData.bpStartTime, boss.bossData.bpFireRate);
    }

    // *****Change this to stop attacking
    public void StopSingleFire()
    {
        CancelInvoke();
    }

    private void SingleFirePoolingSetup()
    {
        // Single Fire projectile data setup
        BasicProjectile basicProjData = basicProjectile.GetComponent<BasicProjectile>();
        basicProjData.speed = boss.bossData.bpSpeed;
        basicProjData.reloadRate = boss.bossData.bpReloadRate;

        // Object pooling setup
        projectiles = new List<GameObject>();
        projectilesToPool = boss.bossData.basicProjectiles;
        projectiles = ObjectPooler.CreateObjectPool(projectilesToPool, basicProjectile);
        projectiles = ObjectPooler.AssignParentGrouping(projectiles, basicProjectileGrouping);
    }
}
