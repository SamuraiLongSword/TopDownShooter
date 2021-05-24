using UnityEngine;

public class DotSpawner : MonoBehaviour
{
    [SerializeField] private GameObject DotEnemy1Prefab;
    [SerializeField] private GameObject DotEnemy2Prefab;
    [SerializeField] private GameObject DotBossPrefab;

    [SerializeField] private int T;
    [SerializeField] private int U;
    [SerializeField] private int Z;

    private int _counterT = 0;
    private int _counterU = 0;
    private int _counterZ = 0;

    private int _maxDotSpawnAmount = 3;

    private float[] _coordsArr = { -9.5f, 0, 9.5f };
    private int _waveCounter = 0;
    private bool _isWaveActive = false;
    private GameObject _currentDot1;
    private GameObject _currentDot2;
    private GameObject _currentDot3;

    private void Start()
    {
        _currentDot1 = null;
        _currentDot2 = null;
        _currentDot3 = null;
    }

    private void Update()
    {
        WaveActivator();
    }

    private void WaveActivator()
    {
        if (!_isWaveActive)
        {
            switch (_waveCounter)
            {
                case 0:
                    _waveCounter++;
                    _isWaveActive = true;
                    Invoke("FirstWave", 5);
                    break;
                case 1:
                    _waveCounter++;
                    _isWaveActive = true;
                    Invoke("FirstWave", 20);
                    Invoke("SecondWave", 20);
                    break;
                case 2:
                    _waveCounter++;
                    ThirdWave();
                    break;
            }
        }
    }

    private void FirstWave()
    {
        Vector2 point = new Vector2(_coordsArr[Random.Range(0, _coordsArr.Length)], _coordsArr[Random.Range(0, _coordsArr.Length)]);
        _currentDot1 = Instantiate(DotEnemy1Prefab, point, Quaternion.identity);
        _currentDot1.GetComponent<Spawner>().OnSpawn += HandlerSpawnFirstEnemy;
    }

    private void SecondWave()
    {
        Vector2 point = new Vector2(_coordsArr[Random.Range(0, _coordsArr.Length)], _coordsArr[Random.Range(0, _coordsArr.Length)]);
        _currentDot2 = Instantiate(DotEnemy2Prefab, point, Quaternion.identity);
        _currentDot2.GetComponent<Spawner>().OnSpawn += HandlerSpawnSecondEnemy;
    }

    private void ThirdWave()
    {
        _currentDot3 = Instantiate(DotBossPrefab, Vector2.zero, Quaternion.identity);
        _currentDot3.GetComponent<Spawner>().OnSpawn += HandleSpawnBoss;
    }

    private void HandlerSpawnFirstEnemy()
    {
        switch (_waveCounter)
        {
            case 1:
                HandleFirstWaveFirstEnemy();
                break;
            case 2:
                HandleSecondtWaveFirstEnemy();
                break;
        }
    }

    private void HandleFirstWaveFirstEnemy()
    {
        EnemyController(ref _counterT, _maxDotSpawnAmount, T, _currentDot1, "FirstWave");

        if (_counterT == T) _isWaveActive = false;
    }

    private void HandleSecondtWaveFirstEnemy()
    {
        EnemyController(ref _counterU, _maxDotSpawnAmount, U, _currentDot1, "FirstWave");

        if (_counterU == U && _counterZ == Z) _isWaveActive = false;
    }

    private void HandlerSpawnSecondEnemy()
    {
        EnemyController(ref _counterZ, _maxDotSpawnAmount, Z, _currentDot2, "SecondWave");

        if (_counterU == U && _counterZ == Z) _isWaveActive = false;
    }

    private void HandleSpawnBoss()
    {
        Destroy(_currentDot3);
    }

    private void EnemyController(ref int counter, int maxDotAmount, int maxCounterAmount, GameObject currentDot, string waveName)
    {
        counter++;

        if (counter % maxDotAmount == 0)
        {
            Destroy(currentDot);
            if(counter != maxCounterAmount) Invoke(waveName, 0);
        }

        if (counter == maxCounterAmount)
        {
            Destroy(currentDot);
        }
    }
}
