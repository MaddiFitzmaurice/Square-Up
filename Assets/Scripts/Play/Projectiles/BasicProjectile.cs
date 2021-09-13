using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public float speed;
    public float reloadRate;
    public Vector3 dir;

    private void OnEnable()
    {
        Invoke("Destroy", reloadRate);
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
