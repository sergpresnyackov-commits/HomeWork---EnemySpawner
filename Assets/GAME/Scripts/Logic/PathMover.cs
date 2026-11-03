using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _pathPoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _reachDistance;

    private Vector3 _nextPosition;
    private float _step;

    private void Start()
    {
        SetRandomNextPosition();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.LookAt(_nextPosition);

        _step = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _step);

        float distance = Vector3.Distance(transform.position, _nextPosition);

        if (distance < _reachDistance)
        {
            SetRandomNextPosition();
        }
    }

    private void SetRandomNextPosition()
    {
        if (_pathPoints.Count != 0)
        {
            int randomIndex = Random.Range(0, _pathPoints.Count);

            _nextPosition = _pathPoints[randomIndex].position;
        }
    }
}