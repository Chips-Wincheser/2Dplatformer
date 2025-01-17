using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed=5f;
    [SerializeField] private Collider2D _patroll¿rea;
    [SerializeField] private Vector3 _scale;

    private Vector2 _direction;
    private float _areaMin;
    private float _areaMax;

    private void Awake()
    {
        _direction = transform.right.normalized;
        _areaMin = Mathf.Round(_patroll¿rea.bounds.min.x);
        _areaMax = Mathf.Round(_patroll¿rea.bounds.max.x);

        _scale = transform.localScale;
    }

    private void Update()
    {
        if(Mathf.Round(transform.position.x) == _areaMax || Mathf.Round(transform.position.x) == _areaMin)
        {
            _scale.x=-_scale.x;
            _direction=-_direction;

            transform.localScale = new Vector3(_scale.x, _scale.y, _scale.z);
        }

        transform.Translate(_direction*_speed*Time.deltaTime, Space.World);
    }
}
