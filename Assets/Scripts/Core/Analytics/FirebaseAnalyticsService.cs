using Firebase;
using Firebase.Analytics;
using Interfaces.Analytics;
using UnityEngine;

namespace Core.Analytics
{
    public class FirebaseAnalyticsService : IAnalyticsProvider
    {
        public void Initialize()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => 
            {
                    Debug.LogWarning("Firebase initialized"); 
            });
        }

        public void TrackEvent(string name)
        {
            Debug.Log("Firebase event name " + name);

            FirebaseAnalytics.LogEvent(name);
        }

        public void TrackEvent(string name, int value)
        {
            Debug.Log("Firebase event name " + name + " score " + value);

            FirebaseAnalytics.LogEvent(name, "score", value);
        }
    }
}