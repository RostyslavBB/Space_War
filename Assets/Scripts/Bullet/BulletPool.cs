using UnityEngine;
using UnityEngine.Pool;

namespace Game.Player
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletsParent;

        private ObjectPool<Bullet> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<Bullet>(
           Create,
           OnGet,
           OnRelease,
           OnDestroyObject,
           defaultCapacity: 20,
           maxSize: 200);
        }

        private Bullet Create()
        {
            Bullet bullet = Instantiate(_bulletPrefab, _bulletsParent);

            bullet.Initialize(this);    

            bullet.gameObject.SetActive(false);

            return bullet;
        }

        private void OnGet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        private void OnRelease(Bullet bullet)
        {
            if (bullet != null) bullet.gameObject.SetActive(false);
        }

        private void OnDestroyObject(Bullet bullet)
        {
            if (bullet != null) Destroy(bullet.gameObject);
        }

        public Bullet Get()
        {
            return _pool.Get();
        }

        public void Release(Bullet bullet)
        {
            if (bullet != null) _pool.Release(bullet);
        }
    }
}