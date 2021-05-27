using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float Speed;

    private GameObject _player;
    private bool _isAlive;

    private void Start()
    {
        if(PlayerMovement.S != null)
        {
            _player = PlayerMovement.S.gameObject;
        }

        _isAlive = true;

        GetComponent<HealthController>().OnDie += HandlerDie;
    }

    private void Update() => Movement();

    private void Movement()
    {
        if (_isAlive && _player != null)
        {
            if (Vector2.Distance(transform.position, _player.transform.position) > 0.5f + transform.localScale.x * GetComponent<CircleCollider2D>().radius)
            {
                Vector2 direction = Vector2.MoveTowards(transform.position, _player.transform.position, 0.25f * Time.deltaTime * Speed);
                transform.position = direction;
            }
        }
    }

    private void HandlerDie() => _isAlive = false;
}
