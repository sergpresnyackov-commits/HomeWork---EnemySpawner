using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private MoverToTarget _enemyMover;

    public void Spawn()
    {
        MoverToTarget enemyMover = Instantiate(_enemyMover, this.transform);

        enemyMover.Init(_target);
    }
}