using UnityEngine;

[RequireComponent(typeof(PlayerInput))]

public class PlayerRotateGun : MonoBehaviour
{
    [SerializeField] private Transform Gun;

    private PlayerInput _pInput;

    private void Awake()
    {
        _pInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        RotateLogic();
    }

    private void RotateLogic()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(_pInput.MousePosition); // Get the World position of the mouse

        float angle = AngleBetweenTwoPoints(Gun.position, mouseWorldPosition); //Get the angle between the gun and the mouse

        Gun.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle)); // Rotate the gun towards the mouse
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}