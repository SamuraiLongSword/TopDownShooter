using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public bool MouseLeft { get; private set; }

    public bool W { get; private set; }
    public bool A { get; private set; }
    public bool S { get; private set; }
    public bool D { get; private set; }
    public bool R { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        MouseLeft = Input.GetButton("Fire1");

        W = Input.GetKey(KeyCode.W);        
        A= Input.GetKey(KeyCode.A);
        S = Input.GetKey(KeyCode.S);
        D = Input.GetKey(KeyCode.D);
        R = Input.GetKey(KeyCode.R);
    }
}
