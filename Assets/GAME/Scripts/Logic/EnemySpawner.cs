using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemySpawnerInput))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Mover _enemyMover;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _spawnDelay;

    private bool _isActive;
    private Coroutine _coroutine;
    private EnemySpawnerInput _spawnerInput;

    private void Awake()
    {
        _spawnerInput = GetComponent<EnemySpawnerInput>();
    }

    private void OnEnable()
    {
        _spawnerInput.MouseClicked += StartStopCounter;
    }

    private void OnDisable()
    {
        _spawnerInput.MouseClicked += StartStopCounter;
    }

    public void StartStopCounter()
    {
        _isActive = !_isActive;

        if (_isActive)
        {
            _coroutine = StartCoroutine(SpawnEnemies(_spawnDelay));
        }
        else
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator SpawnEnemies(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            yield return wait;

            int randomIndex = Random.Range(0, _spawnPoints.Count);

            Mover enemyMover = Instantiate(_enemyMover, _spawnPoints[randomIndex]);

            enemyMover.Init(_moveDirection);
        }
    }
}