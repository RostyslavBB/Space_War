using Interfaces.Analytics;
using System.Collections.Generic;

namespace Core.Analytics
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly List<IAnalyticsProvider> _providers;

        public AnalyticsService(List<IAnalyticsProvider> providers)
        {
            _providers = providers;
        }

        public void TrackEvent(string name)
        {
            foreach (IAnalyticsProvider provider in _providers)
            {
                provider.TrackEvent(name);
            }
        }

        public void TrackEvent(string name, int value)
        {
            foreach (IAnalyticsProvider provider in _providers)
            {
                provider.TrackEvent(name, value);
            }
        }
    }
}