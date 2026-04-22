using Game.DI;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnRate = 2f;

        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Camera _camera;

        private SignalBus _signalBus;
        private Coroutine _spawnCoroutine;

        private float _leftEdge;
        private float _rightEdge;
        private readonly float _padding = 0.5f;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Awake()
        {
            _spawnCoroutine = StartCoroutine(SpawnEnemies());

            _leftEdge = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            _rightEdge = _camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerDeadSignal>(StopSpawning);
        }

        private void OnDisable()
        {
            _signalBus.TryUnsubscribe<OnPlayerDeadSignal>(StopSpawning);
        }

        private IEnumerator SpawnEnemies()
        {
            WaitForSeconds wait = new (_spawnRate);

            while (true)
            {
                Enemy enemy = _enemyPool.Get();

                
                float randomX = Random.Range(_leftEdge + _padding, _rightEdge - _padding);

                enemy.SetPosition(new Vector3(randomX, _spawnPoint.position.y, _spawnPoint.position.z));

                yield return wait;
            }
        }

        private void StopSpawning()
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}