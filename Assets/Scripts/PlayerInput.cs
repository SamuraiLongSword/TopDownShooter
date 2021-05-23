using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public Vector2 MousePosition { get; private set; }
    public bool MouseLeft { get; private set; }
    public bool R { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        MousePosition = Input.mousePosition;
        MouseLeft = Input.GetButton("Fire1");
        R = Input.GetKeyDown(KeyCode.R);
    }
}
