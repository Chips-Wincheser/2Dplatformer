using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Player _player;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopThreshold = 0.1f;
    [SerializeField] private float _stopThresholdAttack = 2f;

    private int _currentWaypoint = 0;
    private float _maximumPlayerDisplacement = 5f;
    private float _direction = 1;
    private bool _isBetween;
    private bool _isFarAway;

    public event Action<bool> CameClose;
    public float Direction => _direction;

    private void Update()
    {
        FindPlayer();

        if ( _isBetween==false)
        {
            PatrollingTerritory();
        }
        else
        {
            FollowPlayer();
        }

        ComparisonDistance();
    }

    private void PatrollingTerritory()
    {
        Rotate(_wayPoints[_currentWaypoint],out Vector3 directionToWaypoint);

        if (directionToWaypoint.sqrMagnitude < _stopThreshold)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position,
            _speed * Time.deltaTime);

        Rotate(_player.transform, out Vector3 _);
    }

    private void FindPlayer()
    {
        float playerPosintoinX=_player.transform.position.x;
        float playerYOffset=_player.transform.position.y- _wayPoints[0].position.y;

        if (playerPosintoinX>_wayPoints[1].position.x && playerPosintoinX<_wayPoints[0].position.x && playerYOffset<_maximumPlayerDisplacement)
        {
            _isBetween = true;
        }
        else
        {
            _isBetween=false;
        }
    }

    private void Rotate(Transform target,out Vector3 directionToWaypoint)
    {
        directionToWaypoint = target.position - transform.position;
        float newDirection = Mathf.Sign(directionToWaypoint.x);

        if (newDirection != _direction)
        {
            _direction = newDirection;
            _rotator.Rotate(_direction);
        }
    }

    private void ComparisonDistance()
    {
        if ((_player.transform.position-transform.position).sqrMagnitude < _stopThresholdAttack)
        {
            _isFarAway=true;
            CameClose?.Invoke(_isFarAway);
        }
        else
        {
            _isFarAway = false;
            CameClose?.Invoke(_isFarAway);
        }
    }
}

