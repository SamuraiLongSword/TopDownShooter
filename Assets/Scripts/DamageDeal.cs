using UnityEngine;

public class DamageDeal : MonoBehaviour
{
    [SerializeField] private float Damage;

    public float DamageToDeal { get { return Damage; } }
}
