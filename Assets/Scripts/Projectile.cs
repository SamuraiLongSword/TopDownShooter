using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float ProjectileSpeed;

    void Update()
    {
        ProjectileMovement();
    }

    private void ProjectileMovement()
    {
        transform.Translate(Time.deltaTime * ProjectileSpeed, 0, 0);

        StartCoroutine(Delite());
    }

    private IEnumerator Delite()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
