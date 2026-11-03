using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private float _step;

    private void Update()
    {
        if (_target != null)
        {
            transform.LookAt(_target.position);

            _step = _speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, _target.position, _step);
        }
    }

    public void Init(Transform target)
    {
        _target = target;
    }
}