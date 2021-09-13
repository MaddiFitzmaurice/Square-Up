using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;

    private int projectilesToPool;

    private Player player;
    private List<GameObject> projectiles;

    private void Start()
    {
        player = GetComponent<Player>();

        // Projectile data setup
        BasicProjectile projData = projectile.GetComponent<BasicProjectile>();
        projData.speed = player.playerData.gravFireSpeed;
        projData.reloadRate = player.playerData.gravFireReloadRate;

        // Object pooling setup
        projectiles = new List<GameObject>();
        projectilesToPool = player.playerData.gravProjectiles;
        projectiles = ObjectPooler.CreateObjectPool(projectilesToPool, projectile);
    }

    public void FireProjectile()
    {
        Vector3 fireDir = player.playerMovement.GetPlayerFireDirection();

        GameObject projectile = ObjectPooler.GetPooledObject(projectiles);

        // If player has projectiles available to fire
        if (projectile != null)
        {
            projectile.transform.position = transform.position;

            // Determine fire direction
            if (fireDir == Vector3.right || fireDir == Vector3.left)
            {
                int rotAngle = fireDir == Vector3.right ? 90 : -90;

                projectile.transform.rotation = Quaternion.Euler(transform.rotation.x, rotAngle, transform.rotation.z);
                projectile.GetComponent<BasicProjectile>().dir = Vector3.forward;
            }
            else
            {
                projectile.transform.rotation = transform.rotation;
                projectile.GetComponent<BasicProjectile>().dir = fireDir;
            }
        
            projectile.SetActive(true);
        }
    }
}
