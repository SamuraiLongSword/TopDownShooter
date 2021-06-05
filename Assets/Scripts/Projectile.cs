using UnityEngine;

/// <summary>
/// Describes projectile moving and destroying
/// </summary>
public class Projectile : MonoBehaviour
{
    [SerializeField] private float ProjectileSpeed;

    void Update() => ProjectileMovement();

    private void ProjectileMovement()
    {
        transform.Translate(Time.deltaTime * ProjectileSpeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<HealthController>();
        if (enemy != null)
        {
            enemy.SendMessage("TakeDamage", GetComponent<DamageDeal>().DamageToDeal);
        }

        Destroy(gameObject);
    }
}
