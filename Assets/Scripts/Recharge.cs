using UnityEngine;

/// <summary>
/// This script is a component of the RechargeDotPrefab
/// </summary>
public class Recharge : MonoBehaviour
{
    [SerializeField] private float TimeBeforeDestroy;

    private void Awake()
    {
        float newPos = Random.Range(-5.5f, 5.5f);
        transform.position = new Vector2(newPos, newPos);

        Invoke("DestroyDot", TimeBeforeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInChildren<BulletHolder>().SendMessage("CanBuy");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponentInChildren<BulletHolder>().SendMessage("CanBuy");
    }

    private void DestroyDot()
    {
        Destroy(gameObject);
    }
}
