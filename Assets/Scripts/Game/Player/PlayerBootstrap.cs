using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private Transform _spawnPoint;

        private PlayerPresenter _playerPresenter;

        [Inject]
        public void Construct(PlayerPresenter presenter)
        {
            _playerPresenter = presenter;
        }

        private void Update()
        {
            _playerPresenter.Move();

            if (_playerPresenter.TryShoot(Time.deltaTime))
            {
                Bullet bullet = _bulletPool.Get();

                bullet.SetPosition(_spawnPoint.position);
            }
        }
    }
}