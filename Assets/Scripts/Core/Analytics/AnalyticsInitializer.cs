using Interfaces.Analytics;
using System.Collections.Generic;
using Zenject;

namespace Core.Analytics
{
    public class AnalyticsInitializer : IInitializable
    {
        private readonly List<IAnalyticsProvider> _providers;

        public AnalyticsInitializer(List<IAnalyticsProvider> providers)
        {
            _providers = providers;
        }

        public void Initialize()
        {
            foreach (IAnalyticsProvider provider in _providers)
            {
                provider.Initialize();
            }
        }
    }
}