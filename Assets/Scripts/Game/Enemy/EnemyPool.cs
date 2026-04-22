using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Game.Enemies
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _enemyParent;

        private IInstantiator _instantiator;

        private ObjectPool<Enemy> _pool;

        [Inject]
        private void Construct(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        private void Awake()
        {
            _pool = new ObjectPool<Enemy>(
           Create,
           OnGet,
           OnRelease,
           OnDestroyObject,
           defaultCapacity: 20,
           maxSize: 200);
        }

        private Enemy Create()
        {
            Enemy enemy = _instantiator.InstantiatePrefabForComponent<Enemy>(_enemyPrefab, _enemyParent);

            enemy.gameObject.SetActive(false);

            return enemy;
        }

        private void OnGet(Enemy enemy)
        {
            enemy.gameObject.SetActive(true);
        }

        private void OnRelease(Enemy enemy)
        {
            if (enemy != null) enemy.gameObject.SetActive(false);
        }

        private void OnDestroyObject(Enemy enemy)
        {
            if (enemy != null) Destroy(enemy.gameObject);
        }

        public Enemy Get()
        {
            return _pool.Get();
        }

        public void Release(Enemy enemy)
        {
            if (enemy != null) _pool.Release(enemy);
        }
    }
}