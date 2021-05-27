using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float ProjectileSpeed;

    void Update() => ProjectileMovement();

    private void ProjectileMovement() => transform.Translate(Time.deltaTime * ProjectileSpeed, 0, 0);

    //private void OnTriggerEnter2D(Collider2D collision) => Destroy(gameObject);

    private void OnCollisionEnter2D(Collision2D collision) => Destroy(gameObject);
}
