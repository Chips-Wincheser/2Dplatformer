using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _speed = 2f;

    private void LateUpdate()
    {
        Vector3 targetPosition =new Vector3(_player.transform.position.x, _player.transform.position.y,transform.position.z);
        transform.position=Vector3.Lerp(transform.position, targetPosition, _speed*Time.deltaTime);
    }
}
