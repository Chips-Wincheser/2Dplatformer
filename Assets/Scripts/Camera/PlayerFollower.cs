using System.Collections;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;
    [SerializeField] private StartCamera _camera;

    private bool _onPlayer = false;

    private void OnEnable()
    {
        _camera.AimedOnPlayer+=TomblerOnPlayer;
    }

    private void OnDisable()
    {
        _camera.AimedOnPlayer-=TomblerOnPlayer;
    }

    private void LateUpdate()
    {
        if (_onPlayer)
            transform.position=new Vector3(_playerMover.transform.position.x, _playerMover.transform.position.y, transform.position.z);
    }

    private void TomblerOnPlayer()
    {
        _onPlayer = true;
    }
}
