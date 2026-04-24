using Game.DI;
using Interfaces.Analytics;
using System;
using Zenject;

namespace Game.Analytics
{
    public class EnemyAnalyticsHandler : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        private readonly IAnalyticsService _analyticsService;

        public EnemyAnalyticsHandler(SignalBus signalBus, IAnalyticsService analyticsService)
        {
            _signalBus = signalBus;
            _analyticsService = analyticsService;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<OnEnemyDeadSignal>(OnEnemyKilled);
        }

        private void OnEnemyKilled(OnEnemyDeadSignal onEnemyDeadSignal)
        {
            _analyticsService.TrackEvent("enemy_destroyed", onEnemyDeadSignal.Score);
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<OnEnemyDeadSignal>(OnEnemyKilled);
        }
    }
}