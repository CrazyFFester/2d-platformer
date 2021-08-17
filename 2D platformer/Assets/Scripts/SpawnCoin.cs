using System.Collections;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private Coin _coin;
    [SerializeField] private float _spawnRate;

    private Transform[] _spawnPoints;
    private int _currentSpawnPoint;
    private bool _roundFinished;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnZone.childCount];
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = _spawnZone.GetChild(i);
        }
        StartCoroutine("PlacingCoins");
    }

    private IEnumerator PlacingCoins()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnRate);

        while (!_roundFinished)
        {
            Instantiate(_coin, _spawnPoints[_currentSpawnPoint].position, Quaternion.identity);
            _currentSpawnPoint++;

            if (_currentSpawnPoint >= _spawnPoints.Length)
            {
                _currentSpawnPoint = 0;
            }

            yield return waitForSeconds;
        }
    }
}