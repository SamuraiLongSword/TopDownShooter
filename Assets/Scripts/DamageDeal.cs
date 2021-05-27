using UnityEngine;

public class DamageDeal : MonoBehaviour, ILaunch
{
    [SerializeField] private float Damage;
    public float DamageToDeal { get { return Damage; } private set { Damage = value; } }

    private float _radius1;
    private float _radius2;

    private void Awake()
    {
        _radius1 = 0;
        _radius2 = 2;
    }

    public void Launch(Launcher launcher)
    {
        if (PlayerMovement.S != null && !gameObject.CompareTag("Projectile"))
        {
            float distance = Vector2.Distance(transform.position, PlayerMovement.S.transform.position);

            if (distance >= _radius1 && distance <= _radius2)
            {
                PlayerMovement.S.GetComponent<HealthController>().SendMessage("TakeDamage", DamageToDeal);
            }
        }
    }
}
