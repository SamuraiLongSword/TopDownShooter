using UnityEngine;

[RequireComponent(typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;

    private PlayerInput _pInput;
    private float _xMax, _xMin, _yMax, _yMin;

    private void Awake()
    {
        _pInput = GetComponent<PlayerInput>();
        _xMax = _yMax = 9.5f;
        _xMin = _yMin = -9.5f;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float deltaX = _pInput.Horizontal * Speed * Time.deltaTime;
        float deltaY = _pInput.Vertical * Speed * Time.deltaTime;

        Vector2 pos = transform.position;
        pos.x += deltaX;
        pos.y += deltaY;
        pos = CheckBounds(pos);

        transform.position = pos;
    }

    private Vector2 CheckBounds(Vector2 pos)
    {
        if (pos.x > _xMax) pos.x = _xMax;
        if (pos.x < _xMin) pos.x = _xMin;
        if (pos.y > _yMax) pos.y = _yMax;
        if (pos.y < _yMin) pos.y = _yMin;

        return pos;
    }
}
