using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float Speed;

    private GameObject _player;
    private bool _isAlive;

    private void Start()
    {
        _player = PlayerMovement.S.gameObject;
        _isAlive = true;

        GetComponent<HealthController>().OnDie += HandlerDie;
    }

    private void Update() => Movement();

    private void Movement()
    {
        if (_isAlive)
        {
            if(Vector2.Distance(transform.position, _player.transform.position) > 1.5f)
            {
                Vector2 direction = Vector2.MoveTowards(transform.position, _player.transform.position, 0.25f * Time.deltaTime * Speed);
                transform.position = direction;
            }
        }
    }

    private void HandlerDie() => _isAlive = false;
}
