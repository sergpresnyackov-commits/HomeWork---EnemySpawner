using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private MoveToTarget _enemyMover;

    public void Spawn()
    {
        MoveToTarget enemyMover = Instantiate(_enemyMover, this.transform);

        enemyMover.Init(_target);
    }
}