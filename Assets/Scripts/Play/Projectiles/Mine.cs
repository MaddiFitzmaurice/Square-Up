using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float speed;
    public float destroyAfter;
    public Transform finalPosition;

    private void OnEnable()
    {
        if (finalPosition != null)
        {
            StartCoroutine(SetMine(finalPosition));
        }
    }

    IEnumerator SetMine(Transform _target)
    {
        while (Vector3.Distance(transform.position, _target.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);

            yield return null;
        }

        // Destroy mine after it has been set in place
        Invoke("Destroy", destroyAfter);
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
