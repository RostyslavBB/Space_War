namespace Interfaces.Analytics
{
    public interface IAnalyticsService
    {
        public void TrackEvent(string name);
        public void TrackEvent(string name, int value);
    }
}