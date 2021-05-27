using System.Collections;
using UnityEngine;

public class EnemyForm : MonoBehaviour
{
    [SerializeField] private int PointsForKill;
    [SerializeField] private float Scale;
    [SerializeField] private SpriteRenderer SRenderer;

    private Vector3 _previousPos;
    private Animator _animator;

    private void Start()
    {
        transform.localScale *= Scale;
        _previousPos = transform.position;
        _animator = GetComponentInChildren<Animator>();

        GetComponent<HealthController>().OnDie += HandlerDie;
        GetComponent<HealthController>().OnHit += HandlerHit;
    }

    private void Update() => EnemyAnimatorController();

    private void EnemyAnimatorController()
    {
        if (transform.position.x > _previousPos.x) SRenderer.flipX = false;
        else SRenderer.flipX = true;

        _previousPos = transform.position;
    }

    private void HandlerDie() => StartCoroutine(Delete());

    private IEnumerator Delete()
    {
        PointCounter.S.MaxPoints = PointsForKill;
        Debug.Log("Max:" + PointCounter.S.MaxPoints + "/Curr:" + PointCounter.S.CurrentPoints);

        _animator.SetTrigger("ShotDown");
        SRenderer.sortingOrder = 0;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(10);

        Destroy(gameObject);
    }

    private void HandlerHit() => StartCoroutine(ChangeColor());

    private IEnumerator ChangeColor()
    {
        Color tmp = SRenderer.color;
        SRenderer.color = Color.yellow;

        yield return new WaitForSeconds(0.05f);

        SRenderer.color = tmp;
    }
}
