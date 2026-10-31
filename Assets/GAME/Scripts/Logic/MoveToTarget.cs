using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (_target != null)
        {
            transform.LookAt(_target);

            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}