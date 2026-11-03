using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseInput))]
public class SpawnerTimer : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _spawners;

    [SerializeField] private float _spawnDelay;

    private bool _isActive;
    private Coroutine _coroutine;
    private MouseInput _inputHandler;

    private void Awake()
    {
        _inputHandler = GetComponent<MouseInput>();
    }

    private void OnEnable()
    {
        _inputHandler.MouseClicked += StartStopCounter;
    }

    private void OnDisable()
    {
        _inputHandler.MouseClicked += StartStopCounter;
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

            int randomIndex = Random.Range(0, _spawners.Count);

            _spawners[randomIndex].Spawn();
        }
    }
}