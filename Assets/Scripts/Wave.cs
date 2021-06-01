using UnityEngine;
using UnityEngine.SceneManagement;

enum IsCentered { No, Yes}

public class Wave : MonoBehaviour
{
    [SerializeField] private int MaxSpawnAmount;
    [SerializeField] private GameObject DotEnemyPrefab;
    [SerializeField] private GameObject NextWavePrefab;
    [SerializeField] private IsCentered Centered;

    public static int TotalSpawnAmount;

    private int _maxDotSpawnAmount = 2;
    private Vector2[] _pointsToSpawn = { new Vector2(-9.5f, 9.5f),  new Vector2(0, 9.5f), new Vector2(9.5f, 9.5f),
                                         new Vector2(-9.5f, 0),                           new Vector2(9.5f, 0),
                                         new Vector2(-9.5f, -9.5f), new Vector2(0, -9.5f),new Vector2(9.5f, -9.5f) };

    private GameObject _currentDot;
    private int _enemyCounter;

    private void Start()
    {
        SceneManager.sceneLoaded += HandlerSceneLoaded;
        TotalSpawnAmount += MaxSpawnAmount;
        _enemyCounter = 0;
        Invoke("WaveLogic", 10);
    }

    private void Update()
    {
        EndWaveCheck();
    }

    private void HandlerSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TotalSpawnAmount = 0;
    }

    private void EndWaveCheck()
    {
        if (PointCounter.S.MobCounter == TotalSpawnAmount)
        {
            if(NextWavePrefab != null) Instantiate(NextWavePrefab);
            Destroy(gameObject);
        }
    }

    private void WaveLogic()
    {
        if(Centered == IsCentered.No)
        {
            Vector2 point = _pointsToSpawn[Random.Range(0, _pointsToSpawn.Length)];
            _currentDot = Instantiate(DotEnemyPrefab, point, Quaternion.identity);
            _currentDot.GetComponent<Spawner>().OnSpawn += HandlerSpawn;
        }
        else
        {
            _currentDot = Instantiate(DotEnemyPrefab, Vector2.zero, Quaternion.identity);
            _currentDot.GetComponent<Spawner>().OnSpawn += HandlerSpawn;
        }
    }

    private void HandlerSpawn()
    {
        _enemyCounter++;

        if (_enemyCounter % _maxDotSpawnAmount == 0)
        {
            Destroy(_currentDot);
            if (_enemyCounter != MaxSpawnAmount) WaveLogic();
        }

        if (_enemyCounter == MaxSpawnAmount)
        {
            Destroy(_currentDot);
        }
    }
}
