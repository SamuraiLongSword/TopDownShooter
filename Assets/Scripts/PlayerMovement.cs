using UnityEngine;

[RequireComponent(typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement S;

    [SerializeField] private float Speed;

    private PlayerInput _pInput;

    private void Awake()
    {
        if (S == null) S = this;

        _pInput = GetComponent<PlayerInput>();
    }

    private void Update() => Movement();

    private void Movement()
    {
        float deltaX = _pInput.Horizontal * Speed;
        float deltaY = _pInput.Vertical * Speed;

        if (!Mathf.Approximately(deltaX, 0) || !Mathf.Approximately(deltaY, 0))
        {
            Vector3 movement = new Vector3(transform.right.x * deltaX, transform.up.y * deltaY, transform.position.z);
            movement = Vector3.ClampMagnitude(movement, Speed);
            movement *= Time.deltaTime;
            transform.Translate(movement);
        }
    }
}
