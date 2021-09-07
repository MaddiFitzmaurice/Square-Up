using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Inputs
    public float horizontalInput;
    public float verticalInput;

    // When player control is taken away
    public bool canControl = true;

    // Raycast length
    private float rayLength = 0.6f;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // Movement checks for 'Grav' state
    #region Grav Movement

    public void GravMove()
    {
        if (CeilingCheck() || FloorCheck())
        {
            player.playerRb.velocity = new Vector3(horizontalInput * player.playerData.gravSpeed, 0, player.playerRb.velocity.z);
        }

        if (RightWallCheck() || LeftWallCheck())
        {
            player.playerRb.velocity = new Vector3(player.playerRb.velocity.x, 0, verticalInput * player.playerData.gravSpeed);
        }
    }

    public void GravEnter()
    {
        // Simulate gravity kicking back in
        player.playerRb.AddForce(-Vector3.forward * 9.81f, ForceMode.Acceleration);
    }

    public bool RightWallCheck()
    {
        return Physics.Raycast(gameObject.transform.position, Vector3.right, rayLength);
    }

    public bool LeftWallCheck()
    {
        return Physics.Raycast(gameObject.transform.position, -Vector3.right, rayLength);
    }

    public bool CeilingCheck()
    {
        return Physics.Raycast(gameObject.transform.position, Vector3.forward, rayLength);
    }

    public bool FloorCheck()
    {
        return Physics.Raycast(gameObject.transform.position, -Vector3.forward, rayLength);
    }
    #endregion

    #region No Grav Movement

    // Indicator that 'no grav' is now active
    public void NoGravEnter()
    {
        canControl = false;
        // Gently push player off of wall
        if (FloorCheck())
        {
            player.playerRb.AddForce(Vector3.forward, ForceMode.Impulse);
        }
        else if (CeilingCheck())
        {
            player.playerRb.AddForce(-Vector3.forward, ForceMode.Impulse);
        }
        else if (LeftWallCheck())
        {
            player.playerRb.AddForce(Vector3.right, ForceMode.Impulse);
        }
        else if (RightWallCheck())
        {
            player.playerRb.AddForce(-Vector3.right, ForceMode.Impulse);
        }

        StartCoroutine(CoroutineWaitTimer());
    }

    public void NoGravMove()
    {
        if (canControl)
        {
            player.playerRb.AddForce(Vector3.forward * player.playerData.noGravSpeed * verticalInput, ForceMode.Impulse);
            player.playerRb.AddForce(Vector3.right * player.playerData.noGravSpeed * horizontalInput, ForceMode.Impulse);
        }
    }
    #endregion

    IEnumerator CoroutineWaitTimer()
    {
        yield return new WaitForSeconds(2.5f);
        canControl = true;
    }

    public void ResetPlayerVelocity()
    {
        player.playerRb.velocity = Vector3.zero;
    }
}
