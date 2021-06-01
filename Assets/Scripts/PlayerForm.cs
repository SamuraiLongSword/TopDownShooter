using System.Collections;
using UnityEngine;

public class PlayerForm : MonoBehaviour
{
    private SpriteRenderer _sRenderer;

    private void Start()
    {
        GetComponent<HealthController>().OnDie += HandlerDie;
        GetComponent<HealthController>().OnHit += HandlerHit;

        _sRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void HandlerDie()
    {
        Destroy(gameObject);
    }

    private void HandlerHit() => StartCoroutine(Hit());

    private IEnumerator Hit()
    {
        Color tmp = Color.white;
        _sRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _sRenderer.color = tmp;
    }
}
