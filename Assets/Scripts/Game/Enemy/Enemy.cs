using Game.DI;
using Game.Player;
using Interfaces.Score;
using UnityEngine;
using Zenject;

namespace Game.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private EnemyPool _enemyPool;
        private SignalBus _signalBus;

        private IScoreService _scoreService;

        [Inject]
        private void Construct(IScoreService scoreService, EnemyPool enemyPool, SignalBus signalBus)
        {
            _scoreService = scoreService;
            _enemyPool = enemyPool;
            _signalBus = signalBus;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out Bullet bullet))
            {
                bullet.Release();

                _scoreService.AddScore(1);

                _signalBus.Fire(new OnEnemyDeadSignal { Score = 1 });

                Death();
            }

            if (collision.gameObject.TryGetComponent(out PlayerView playerView))
            {
                _enemyPool.Release(this);

                playerView.Death();
            }
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerDeadSignal>(Death);
        }

        private void Death()
        {
            _enemyPool.Release(this);
        }

        private void OnDisable()
        {
            _signalBus.TryUnsubscribe<OnPlayerDeadSignal>(Death);
        }

        public void SetPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}