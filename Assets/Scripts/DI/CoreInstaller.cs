using Core.Ads;
using Core.Analytics;
using Game.Analytics;
using Interfaces.Ads;
using Interfaces.Analytics;
using Zenject;

namespace Game.DI
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAnalyticsProvider>().To<FirebaseAnalyticsService>().AsSingle();
            Container.Bind<IAnalyticsProvider>().To<FacebookAnalyticsService>().AsSingle();

            Container.Bind<IAnalyticsService>().To<AnalyticsService>().AsSingle();

            Container.BindInterfacesTo<AnalyticsInitializer>().AsSingle();
            Container.BindInterfacesTo<GameAnalyticsHandler>().AsSingle();
            Container.BindInterfacesTo<EnemyAnalyticsHandler>().AsSingle();

            Container.Bind<IAdsService>().To<AdMobService>().AsSingle();
            Container.BindInterfacesTo<AdsInitializer>().AsSingle();
            Container.BindInterfacesTo<GameAdsHandler>().AsSingle();
        }
    }
}
