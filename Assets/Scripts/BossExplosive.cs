using System.Collections;
using UnityEngine;

public class BossExplosive : MonoBehaviour
{
    [SerializeField] private GameObject ExplosivePrefab;

    private GameObject[] _explosivesArr = new GameObject[10];

    private void Start()
    {
        GetComponent<EnemyForm>().OnWin += HandlerWin;
    }

    private void HandlerWin()
    {
        StartCoroutine(MassiveExplosive());
    }

    private IEnumerator MassiveExplosive()
    {
        for (int i = 0; i < _explosivesArr.Length; i++)
        {
            Vector2 point = new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1), Random.Range(transform.position.y - 1, transform.position.y + 1));

            _explosivesArr[i] = Instantiate(ExplosivePrefab, point, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }

        for (int i = 0; i < _explosivesArr.Length; i++)
        {
            Destroy(_explosivesArr[i].gameObject);
        }
    }
}
