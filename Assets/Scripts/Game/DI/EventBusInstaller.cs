using Zenject;

namespace Game.DI
{
    public class EventBusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<OnPlayerDeadSignal>();

            SignalBusInstaller.Install(Container);
        }
    }
}