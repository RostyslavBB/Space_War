using UnityEngine;

namespace Game.Enemies
{
    public class EnemyLimits : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                _enemyPool.Release(enemy);
            }
        }
    }
}