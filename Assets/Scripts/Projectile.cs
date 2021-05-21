using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-Time.deltaTime * 5, 0, 0);

        StartCoroutine(Delite());
    }

    private IEnumerator Delite()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
