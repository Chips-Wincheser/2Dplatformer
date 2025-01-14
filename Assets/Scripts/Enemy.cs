using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed=5f;
    [SerializeField] private Collider2D _patroll¿rea;

    private Vector2 _direction;
    private float _areaMin;
    private float _areaMax;
    private float _scaleX;
    private float _scaleY;
    private float _scaleZ;

    private void Awake()
    {
        _direction = transform.right.normalized;
        _areaMin = Mathf.Round(_patroll¿rea.bounds.min.x);
        _areaMax = Mathf.Round(_patroll¿rea.bounds.max.x);
        _scaleX = 2;
        _scaleY = 2;
        _scaleZ = 2;
    }

    private void Update()
    {
        if(Mathf.Round(transform.position.x) == _areaMax || Mathf.Round(transform.position.x) == _areaMin)
        {
            _scaleX=-_scaleX;
            _direction=-_direction;

            transform.localScale = new Vector3(_scaleX, _scaleY, _scaleZ);
        }

        transform.Translate(_direction*_speed*Time.deltaTime, Space.World);
    }
}
