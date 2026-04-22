using Game.Player;
using UnityEngine;

namespace Game.Limits
{
    public class BulletLimits : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Bullet bullet))
            {
                _bulletPool.Release(bullet);
            }
        }
    }
}