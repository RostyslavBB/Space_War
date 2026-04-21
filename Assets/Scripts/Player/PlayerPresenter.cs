using Game.Input;
using UnityEngine;

namespace Game.Player
{
    public class PlayerPresenter
    {
        private readonly PlayerView _playerView;
        private readonly PlayerModel _playerModel;
        private readonly PlayerInput _playerInput;
        private readonly Camera _camera;

        public PlayerPresenter(PlayerView playerView, PlayerModel playerModel, PlayerInput playerInput, Camera camera)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _playerInput = playerInput;
            _camera = camera;
        }

        public void Move()
        {
            if (!_playerInput.IsPressed) return;

            Vector3 screenPosition = new(_playerInput.Position.x, _playerInput.Position.y, 0f);
            Vector3 worldPosition = _camera.ScreenToWorldPoint(screenPosition);

            Vector3 current = _playerView.transform.position;

            float targetX = worldPosition.x;

            float newX = Mathf.Lerp(current.x, targetX, _playerModel.PlayerSettings.Speed * Time.deltaTime);    

            _playerView.SetNewPosition(new(newX, current.y, current.z));
        }
    }
}