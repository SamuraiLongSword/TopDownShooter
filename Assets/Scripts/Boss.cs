using UnityEngine;

public class Boss : EnemyMovement
{
    private void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        if (_isAlive && _player != null)
        {
            if (Vector2.Distance(transform.position, _player.transform.position) > 0.5f + transform.localScale.x * GetComponent<CircleCollider2D>().radius)
            {
                base.Movement();
            }
            else
            {
                transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-8f, 8f));
            }
        }
    }
}
