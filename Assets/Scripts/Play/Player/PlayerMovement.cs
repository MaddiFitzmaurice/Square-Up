using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Inputs
    public float horizontalInput;
    public float verticalInput;

    private Player player;

    // When player control is taken away
    public bool canControl = true;

    // Raycast length
    private float rayLength = 0.6f;

    // Start State variables
    private Vector3 endPos = new Vector3(-5.0f, 0, -11.8f);
    private float startSpeed = 3;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    #region StartState Movement

    public void MoveToStartPos()
    {
        StartCoroutine(ToStartPos(endPos));
    }

    IEnumerator ToStartPos(Vector3 _target)
    {
        canControl = false;
        while (Vector3.Distance(transform.position, _target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, startSpeed * Time.deltaTime);

            yield return null;
        }

        canControl = true;
    }
    #endregion

    // Movement for 'Grav' state
    #region Grav Movement
    public void GravMove()
    {
        if (canControl)
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
    }

    public void GravEnter()
    {
        // Simulate gravity kicking back in
        player.playerRb.AddForce(-Vector3.forward * 9.81f, ForceMode.Impulse);
    }

    // Wall checks
    public bool RightWallCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, Vector3.right, out hit, rayLength))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return true;
            }    
            else
            {
                return false;
            }
        }

        return false;
    }

    public bool LeftWallCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, -Vector3.right, out hit, rayLength))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool CeilingCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, rayLength))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool FloorCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, -Vector3.forward, out hit, rayLength))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
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

        StartCoroutine(FloatingWaitTimer());
    }

    public void NoGravMove()
    {
        if (canControl)
        {
            player.playerRb.AddForce(Vector3.forward * player.playerData.noGravSpeed * verticalInput, ForceMode.Impulse);
            player.playerRb.AddForce(Vector3.right * player.playerData.noGravSpeed * horizontalInput, ForceMode.Impulse);
        }
    }
    
    IEnumerator FloatingWaitTimer()
    {
        yield return new WaitForSeconds(1.5f);
        canControl = true;
    }

    #endregion

    public void ResetPlayerVelocity()
    {
        player.playerRb.velocity = new Vector3(0, 0, 0);
    }

    public Vector3 GetPlayerFireDirection()
    {
        if (FloorCheck())
        {
            return Vector3.forward;
        }
        else if (CeilingCheck())
        {
            return Vector3.back;
        }
        else if (RightWallCheck())
        {
            return Vector3.left;
        }
        else
        {
            return Vector3.right;
        }
    }
}
