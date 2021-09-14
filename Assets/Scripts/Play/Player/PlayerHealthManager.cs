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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossSingleFire"))
        {
            player.playerData.health -= 1;
            other.gameObject.SetActive(false);

            if (player.playerData.health == 0)
            {
                // Gameover logic here
            }
        }
    }


}
