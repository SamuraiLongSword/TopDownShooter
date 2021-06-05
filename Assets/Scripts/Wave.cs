using UnityEngine;
using UnityEngine.SceneManagement;

enum IsCentered { No, Yes}

/// <summary>
/// Describes the appearing of the waves
/// </summary>
public class Wave : MonoBehaviour
{
    [SerializeField] private int MaxSpawnAmount;        // Max enemies appearing in this wave
    [SerializeField] private GameObject DotEnemyPrefab;
    [SerializeField] private GameObject NextWavePrefab;
    [SerializeField] private IsCentered Centered;
    [SerializeField] private int MaxDotSpawnAmount;     // Max enemies appearing in the current point

    public static int TotalSpawnAmount;

    // Possible spawn points for enemies
    private Vector2[] _pointsToSpawn = { new Vector2(-9.5f, 9.5f),  new Vector2(0, 9.5f), new Vector2(9.5f, 9.5f),
                                         new Vector2(-9.5f, 0),                           new Vector2(9.5f, 0),
                                         new Vector2(-9.5f, -9.5f), new Vector2(0, -9.5f),new Vector2(9.5f, -9.5f) };

    private GameObject _currentDot;
    private int _enemyCounter;

    private void Start()
    {
        SceneManager.sceneLoaded += HandlerSceneLoaded;
        TotalSpawnAmount += MaxSpawnAmount;             // Summing up the number of enemies in all instances of the class
        _enemyCounter = 0;
        Invoke("WaveLogic", 10);
    }

    private void Update()
    {
        EndWaveCheck();
    }

    // When loading the scene, reset the variable with the total number of enemies in the current session
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
            // Instantiate the enemies
            Vector2 point = _pointsToSpawn[Random.Range(0, _pointsToSpawn.Length)];
            _currentDot = Instantiate(DotEnemyPrefab, point, Quaternion.identity);
            _currentDot.GetComponent<Spawner>().OnSpawn += HandlerSpawn;
        }
        else
        {
            // Instantiate the boss
            _currentDot = Instantiate(DotEnemyPrefab, Vector2.zero, Quaternion.identity);
            _currentDot.GetComponent<Spawner>().OnSpawn += HandlerSpawn;
        }
    }

    private void HandlerSpawn()
    {
        _enemyCounter++;

        // If the current dot is out of enemies, destroy that dot and start up the new one
        if (_enemyCounter % MaxDotSpawnAmount == 0)
        {
            Destroy(_currentDot);
            if (_enemyCounter != MaxSpawnAmount) WaveLogic();
        }

        // If the current wave is out of enemies, just destroy the current dot
        if (_enemyCounter == MaxSpawnAmount)
        {
            Destroy(_currentDot);
        }
    }
}
