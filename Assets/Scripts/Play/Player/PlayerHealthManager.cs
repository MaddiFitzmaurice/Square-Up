using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    // Interacting with objects that could damage/trigger a game over
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossSingleFire"))
        {
            player.playerData.health -= other.GetComponent<BasicProjectile>().damage;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("BossAreaFire"))
        {
            player.playerData.health -= other.GetComponent<BasicProjectile>().damage;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("BossMine"))
        {
            player.playerData.health -= other.GetComponent<Mine>().damage;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("BossTrackerFire"))
        {
            player.playerData.health -= other.GetComponent<TrackerProjectile>().damage;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("LaunchpadTrigger"))
        {
            // Check if in GravState not AttackState
            // Rising launchpads trigger a game over if caught on one
            if (player.stateMachine.currentState == player.playerGravState)
            {
                // Game over logic here
                Debug.Log("You died.");
            }
        }
    }

    // When Player collides with Boss's shield
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            // Check if shield is active
            if (collision.gameObject.GetComponent<Boss>().bossHealthManager.shield.activeInHierarchy)
            {
                // Get surface normal of contact point and blow player back in opposite direction
                ContactPoint contactPoint = collision.GetContact(0);
                player.playerRb.AddForce(contactPoint.normal * 20, ForceMode.Impulse);
                // Need to add boss shield damage and shield explosion force for above line
            }
        }
    }
}
