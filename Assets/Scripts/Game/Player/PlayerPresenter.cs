using Game.Input;
using UnityEngine;

namespace Game.Player
{
    public class PlayerPresenter
    {
        private readonly PlayerView _playerView;
        private readonly PlayerInput _playerInput;
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerShooting _playerShooting;

        public PlayerPresenter(PlayerView playerView, PlayerInput playerInput, PlayerMovement playerMovement, PlayerShooting playerShooting)
        {
            _playerView = playerView;
            _playerInput = playerInput;
            _playerMovement = playerMovement;
            _playerShooting = playerShooting;
        }

        public void Move()
        {
            if (!_playerInput.IsPressed) return;

            Vector3 current = _playerView.Position;

            float newX = _playerMovement.CalculateX(current.x, _playerView.GetWorldPosition(_playerInput).x, Time.deltaTime);    

            _playerView.SetNewPosition(new(newX, current.y, current.z));
        }

        public bool TryShoot(float dt)
        {
            return _playerShooting.CanShoot(dt);
        }
    }
}