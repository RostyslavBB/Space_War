using Game.DI;
using Interfaces.Analytics;
using System;
using Zenject;

namespace Core.Analytics
{
    public class GameAnalyticsHandler : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        private readonly IAnalyticsService _analyticsService;

        public GameAnalyticsHandler(SignalBus signalBus, IAnalyticsService analyticsService)
        {
            _signalBus = signalBus;
            _analyticsService = analyticsService;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<OnPlayerDeadSignal>(OnGameOver);
        }

        private void OnGameOver()
        {
            _analyticsService.TrackEvent(AnalyticsEvents.GameOver);
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<OnPlayerDeadSignal>(OnGameOver);
        }
    }
}