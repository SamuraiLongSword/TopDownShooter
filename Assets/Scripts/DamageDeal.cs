using UnityEngine;

/// <summary>
/// Damage dealing
/// </summary>
public class DamageDeal : MonoBehaviour, ILaunch
{
    [SerializeField] private float Damage;
    [SerializeField] private CircleCollider2D Radius1;
    [SerializeField] private CircleCollider2D Radius2;
    [SerializeField] private LayerMask PlayerMask;

    public float DamageToDeal { get { return Damage; } private set { Damage = value; } }

    private bool _isInRange1 = false;
    private bool _isInRange2 = false;

    private void FixedUpdate()
    {
        CheckIfPlayerIsInDamageZone();
    }

    private void CheckIfPlayerIsInDamageZone()
    {
        if (Radius1 != null) _isInRange1 = Physics2D.OverlapCircle(transform.position, Radius1.radius * Radius1.transform.localScale.x * transform.localScale.x, PlayerMask);
        if (Radius2 != null) _isInRange2 = Physics2D.OverlapCircle(transform.position, Radius2.radius * Radius2.transform.localScale.x * transform.localScale.x, PlayerMask);
    }

    public void Launch(Launcher launcher)
    {
        if (PlayerMovement.S != null && !gameObject.CompareTag("Projectile"))
        {
            if (_isInRange2 && !_isInRange1)
            {
                PlayerMovement.S.GetComponent<HealthController>().SendMessage("TakeDamage", DamageToDeal);
            }
        }
    }
}
