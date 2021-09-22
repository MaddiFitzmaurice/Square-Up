using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public GameObject basicProjectile;
    public Transform basicProjectileGrouping;

    private int projectilesToPool;

    private Boss boss;

    // String name for types of attacks
    public string singleFire = "SingleFire";
    public string areaFire = "AreaFire";

    // All projectiles available
    private List<GameObject> projectiles;

    // Area Fire projectiles
    private List<GameObject> areaProjectiles;

    private void Start()
    {
        boss = GetComponent<Boss>();

        ProjectilePoolingSetup();
        
        areaProjectiles = new List<GameObject>();
}

    // Start Boss's specified attack
    public void StartAttack(string _methodName, float _startTime, float _repeatRate)
    {
        InvokeRepeating(_methodName, _startTime, _repeatRate);
    }

    // Stop Boss's current attack
    public void StopAttack()
    {
        CancelInvoke();
    }

    #region Single Fire

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

    // Set up for attacks that use basic projectiles (Single Fire & Area Fire)
    private void ProjectilePoolingSetup()
    {
        // Basic projectile data setup
        BasicProjectile basicProjData = basicProjectile.GetComponent<BasicProjectile>();
        basicProjData.speed = boss.bossData.bpSpeed;
        basicProjData.destroyAfter = boss.bossData.bpDestroyAfter;

        // Object pooling setup
        projectiles = new List<GameObject>();
        projectilesToPool = boss.bossData.basicProjectiles;
        projectiles = ObjectPooler.CreateObjectPool(projectilesToPool, basicProjectile);
        projectiles = ObjectPooler.AssignParentGrouping(projectiles, basicProjectileGrouping);
    }

    #endregion

    #region Area Fire

    // Shoot 8 projectiles in 8 directions
    public void AreaFire()
    {
        areaProjectiles.Clear();

        for (int i = 0; i < 8; i++)
        {
            GameObject areaProjectile = ObjectPooler.GetPooledObject(projectiles);

            // Keep looking until projectile is not null
            while (areaProjectile == null)
            {
                
                areaProjectile = ObjectPooler.GetPooledObject(projectiles);
            }

            // Activate it so it is not picked up again on next iteration
            areaProjectile.gameObject.SetActive(true);
            areaProjectiles.Add(areaProjectile);
        }

        float angle = 0;

        foreach (var proj in areaProjectiles)
        {
            angle += 45;
            proj.transform.position = transform.position;
            proj.transform.rotation = transform.rotation;
            proj.GetComponent<BasicProjectile>().dir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            proj.SetActive(true);
        }   
    }

    #endregion
}
