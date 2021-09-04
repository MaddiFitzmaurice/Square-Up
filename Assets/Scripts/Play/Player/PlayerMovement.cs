using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    private float rayLength = 0.6f;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // Movement checks for 'No Grav' state
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
}
