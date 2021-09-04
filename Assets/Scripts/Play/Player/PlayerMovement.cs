using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float rayLength;

    public bool checkWall;
    public bool checkFloorCeiling;

    private int playerHoriDir = 1;
    private int playerVertDir = -1;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        WallCheck();
        FloorCeilingCheck();
    }

    public bool WallCheck()
    {
        if (horizontalInput != 0 && Mathf.Sign(horizontalInput) != playerHoriDir)
        {
            playerHoriDir *= -1;
        }
        checkWall = Physics.Raycast(gameObject.transform.position, Vector3.right * playerHoriDir, rayLength);
        return checkWall;
    }

    public bool FloorCeilingCheck()
    {
        if (verticalInput != 0 && Mathf.Sign(verticalInput) != playerVertDir)
        {
            playerVertDir *= -1;
        }
        checkFloorCeiling = Physics.Raycast(gameObject.transform.position, Vector3.forward * playerVertDir, rayLength);
        return checkFloorCeiling;
    }
}
