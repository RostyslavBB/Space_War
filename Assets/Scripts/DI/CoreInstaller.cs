using Core.Analytics;
using Game.Analytics;
using Interfaces.Analytics;
using Zenject;

namespace Game.DI
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAnalyticsProvider>().To<FirebaseAnalyticsService>().AsSingle();

            Container.Bind<IAnalyticsService>().To<AnalyticsService>().AsSingle();
            Container.BindInterfacesTo<AnalyticsInitializer>().AsSingle();

            Container.BindInterfacesTo<EnemyAnalyticsHandler>().AsSingle();
        }
    }
}
