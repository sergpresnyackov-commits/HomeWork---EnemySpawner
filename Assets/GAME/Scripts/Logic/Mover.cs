using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction = Vector3.zero;

    private float _step;

    private void Update()
    {
        _step = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _step);
    }

    public void Init(Vector3 direction)
    {
        _direction = direction;
        transform.LookAt(direction);
    }
}