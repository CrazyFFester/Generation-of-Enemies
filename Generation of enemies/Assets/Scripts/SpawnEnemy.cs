using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _amountOfEnemies;
    [SerializeField] private float _spawnRate;

    private Transform[] _spawnPoints;
    private int _currentSpawnPoint;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnZone.childCount];
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = _spawnZone.GetChild(i);
        }

        StartCoroutine(PlacingEnemies());
    }

    private IEnumerator PlacingEnemies()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnRate);

        for (int i = 0; i < _amountOfEnemies; i++)
        {
            Instantiate(_enemy, _spawnPoints[_currentSpawnPoint].position, Quaternion.identity);
            _currentSpawnPoint++;

            if (_currentSpawnPoint >= _spawnPoints.Length)
            {
                _currentSpawnPoint = 0;
            }

            yield return waitForSeconds;
        }
    }
}