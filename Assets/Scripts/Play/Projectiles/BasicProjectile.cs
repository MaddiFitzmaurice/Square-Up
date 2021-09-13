using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public float speed;

    public Vector3 dir;

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }
}
