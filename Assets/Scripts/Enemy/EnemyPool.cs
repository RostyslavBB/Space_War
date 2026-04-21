using UnityEngine;
using UnityEngine.Pool;

namespace Game.Enemies
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _enemyParent;

        private ObjectPool<Enemy> _pool;

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
            Enemy enemy = Instantiate(_enemyPrefab, _enemyParent);

            enemy.Initialize(this);

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