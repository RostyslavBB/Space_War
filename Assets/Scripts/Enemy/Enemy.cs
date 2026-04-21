using Game.Player;
using UnityEngine;

namespace Game.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private EnemyPool _enemyPool;

        public void Initialize(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out Bullet bullet))
            {
                bullet.Release();

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