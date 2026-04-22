using Game.Player;
using Interfaces.Score;
using UnityEngine;
using Zenject;

namespace Game.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private EnemyPool _enemyPool;

        private IScoreService _scoreService;

        [Inject]
        private void Construct(IScoreService scoreService, EnemyPool enemyPool)
        {
            _scoreService = scoreService;
            _enemyPool = enemyPool;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out Bullet bullet))
            {
                bullet.Release();

                _scoreService.AddScore(1);

                _enemyPool.Release(this);
            }

            if (collision.gameObject.TryGetComponent(out PlayerView playerView))
            {
                playerView.Death();

                _enemyPool.Release(this);
            }
        }

        public void SetPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}