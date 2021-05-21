using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private Transform ShootPoint;

    private float _timer;

    private void Awake()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && _timer > 0.35f)
        {
            Shoot();
            _timer = 0;
        }
    }

    private void Shoot()
    {
        Instantiate(ProjectilePrefab, ShootPoint.position, transform.rotation);
    }
}
