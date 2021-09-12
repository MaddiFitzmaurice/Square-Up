using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;

    public int projectilesToPool;

    private List<GameObject> projectiles;

    private void Start()
    {
        projectiles = new List<GameObject>();
        CreateProjectilePool();
    }

    public void FireProjectile()
    {

    }

    public void CreateProjectilePool()
    {
        for (int i = 0; i < projectilesToPool; i++)
        {
            GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity);
            obj.SetActive(false);
            projectiles.Add(obj);
        }
    }
}
