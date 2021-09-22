using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public float speed;
    public float destroyAfter;
    public Vector3 dir;

    private void OnEnable()
    {
        Invoke("Destroy", destroyAfter);
    }

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
