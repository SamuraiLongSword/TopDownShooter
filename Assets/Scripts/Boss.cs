using UnityEngine;

public class Boss : Enemy
{
    

    private void Awake()
    {
        SRenderer.material.color = Color.red;
    }
}
