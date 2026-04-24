namespace Interfaces.Analytics
{
    public interface IAnalyticsProvider
    {
        public void Initialize();
        public void TrackEvent(string name);
        public void TrackEvent(string name, int value);
    }
}