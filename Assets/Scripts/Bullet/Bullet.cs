using UnityEngine;

namespace Game.Player
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 20f;

        private BulletPool _bulletPool;

        public void Initialize(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        private void Update()
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.up);
        }

        public void SetPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        public void Release()
        {
            _bulletPool.Release(this);
        }
    }
}