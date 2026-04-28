using Game.DI;
using Interfaces.Ads;
using System;
using Zenject;

namespace Core.Ads
{
    public class GameAdsHandler : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        private readonly IAdsService _adsService;

        public GameAdsHandler(SignalBus signalBus, IAdsService adsService)
        {
            _signalBus = signalBus;
            _adsService = adsService;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<OnPlayerDeadSignal>(OnGameOver);
        }

        private void OnGameOver()
        {
            _adsService.ShowInterestial();
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<OnPlayerDeadSignal>(OnGameOver);
        }
    }
}