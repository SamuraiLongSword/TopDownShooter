using UnityEngine;

/// <summary>
/// Describes Boss behaviour
/// </summary>
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
                // If the boss reached the player it teleports to the random point on the map
                transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-8f, 8f));
            }
        }
    }
}
