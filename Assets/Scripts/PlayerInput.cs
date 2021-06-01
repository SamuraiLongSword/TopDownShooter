using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public Vector2 MousePosition { get; private set; }
    public bool MouseLeft { get; private set; }
    public bool R { get; private set; }
    public bool F { get; private set; }

    private bool _isOnControl;
    public bool IsOnControl
    {
        get { return _isOnControl; }
        set
        {
            _isOnControl = value;
            Horizontal = 0;
            Vertical = 0;
            MouseLeft = false;
        }
    }

    private void Start()
    {
        IsOnControl = true;
    }

    private void Update()
    {
        if (IsOnControl)
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            MousePosition = Input.mousePosition;
            MouseLeft = Input.GetButton("Fire1");
            R = Input.GetKeyDown(KeyCode.R);
            F = Input.GetKeyDown(KeyCode.F);
        }
    }
}
