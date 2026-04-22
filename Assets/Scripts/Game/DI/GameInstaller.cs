using UnityEngine;
using Zenject;
using Game.Player;
using Game.Enemies;
using Game.Input;
using Game.Score;
using Interfaces.Score;

namespace Game.DI
{
    public class GameInstaller : MonoInstaller
    {
        [Header("System References")]
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private PlayerSettings _playerSettings;

        [Header("Player References")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerInput _input;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().AsSingle().WithArguments(_playerSettings);

            Container.Bind<PlayerMovement>().AsSingle();
            Container.Bind<PlayerShooting>().AsSingle();

            Container.Bind<PlayerPresenter>().AsSingle();

            Container.BindInstance(_playerView).AsSingle();
            Container.BindInstance(_input).AsSingle();

            Container.Bind<IScoreService>().FromInstance(_scoreSystem).AsSingle();

            Container.Bind<EnemyPool>().FromInstance(_enemyPool).AsSingle();

            Container.Bind<BulletPool>().FromInstance(_bulletPool).AsSingle();
        }
    }
}