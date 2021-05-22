using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float Scale;
    [SerializeField] protected float Speed;
    [SerializeField] protected float Damage;
    [SerializeField] protected float Range;
    [SerializeField] protected float Health;

    [SerializeField] protected SpriteRenderer SRenderer;

    private Vector3 _previousPos;

    protected GameObject _player;

    private void Start()
    {
        _player = PlayerMovement.S.gameObject;
        transform.localScale *= Scale;
        _previousPos = transform.position;
    }

    private void Update()
    {
        Vector2 direction = Vector2.MoveTowards(transform.position, _player.transform.position, 0.25f * Time.deltaTime * Speed);
        transform.position = direction;

        if (transform.position.x > _previousPos.x) SRenderer.flipX = false;
        else SRenderer.flipX = true;

        _previousPos = transform.position;
    }

}
