using Game.Input;
using UnityEngine;

namespace Game.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private PlayerInput _playerInput;

        private PlayerPresenter _playerPresenter;

        private void Awake()
        {
            PlayerModel playerModel = new(_playerSettings);

            _playerPresenter = new(this, playerModel, _playerInput, _camera);
        }

        private void Update()
        {
            _playerPresenter.Move();
        }

        public void SetNewPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}