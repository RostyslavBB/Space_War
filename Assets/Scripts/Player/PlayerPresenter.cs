using Game.Input;
using System.Collections;
using UnityEngine;

namespace Game.Player
{
    public class PlayerPresenter
    {
        private readonly PlayerView _playerView;
        private readonly PlayerModel _playerModel;
        private readonly PlayerInput _playerInput;
        private readonly Camera _camera;
        private readonly BulletPool _bulletPool;
        private readonly Transform _spawnPoint;

        public PlayerPresenter(PlayerView playerView, PlayerModel playerModel, PlayerInput playerInput, Camera camera,
            BulletPool bulletPool, Transform spawnPoint)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _playerInput = playerInput;
            _camera = camera;
            _bulletPool = bulletPool;
            _spawnPoint = spawnPoint;
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

        public IEnumerator Shooting()
        {
            while(true)
            {
                Bullet bullet = _bulletPool.Get();

                bullet.SetPosition(_spawnPoint.position);

                yield return new WaitForSeconds(_playerModel.PlayerSettings.ShootRate);
            }
        }
    }
}