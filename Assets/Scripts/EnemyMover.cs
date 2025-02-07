using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopThreshold = 0.1f;

    private int _currentWaypoint = 0;
    private float _direction = 1;

    private void Update()
    {
        if ((_wayPoints[_currentWaypoint].position-transform.position).sqrMagnitude<_stopThreshold)
        {
            _currentWaypoint = ++_currentWaypoint % _wayPoints.Length;
            _direction=-_direction;
            _rotator.Rotate(_direction);
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position,
            _speed * Time.deltaTime);
    }
}

