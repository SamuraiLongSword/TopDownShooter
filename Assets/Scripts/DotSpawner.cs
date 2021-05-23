using System.Collections;
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

    private int _maxDotSpawnAmount = 5;

    private float[] _coordsArr = { -9.5f, 0, 9.5f };
    private int _waveCounter = 0;
    private bool _isWaveActive = false;
    private GameObject _currentDot1;
    private GameObject _currentDot2;

    private void Start()
    {
        _currentDot1 = null;
        _currentDot2 = null;
    }

    private void Update()
    {
        WaveActivator();

        if(_counterT % 5 == 0 && _currentDot1 == null && _counterT != T)
        {
            FirstWave();
        }
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
                    FirstWave();
                    break;
                case 1:
                    _waveCounter++;
                    _isWaveActive = true;
                    SecondWave();
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
        _currentDot1.GetComponent<Spawner>().OnSpawn += HandlerSpawn;
    }

    private void SecondWave()
    {
        _isWaveActive = false;

        if (_counterU == U && _counterZ == Z) _isWaveActive = false;
    }

    private void ThirdWave()
    {
        Instantiate(DotBossPrefab, Vector2.zero, Quaternion.identity);
    }

    private void HandlerSpawn()
    {
        _counterT++;

        if (_counterT == T) _isWaveActive = false;
    }
}
