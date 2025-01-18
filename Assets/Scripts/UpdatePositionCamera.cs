using UnityEngine;

public class UpdatePositionCamera : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;

    private void Update()
    {
        transform.position=new Vector3(_playerMover.transform.position.x, _playerMover.transform.position.y,transform.position.z);
    }
}
