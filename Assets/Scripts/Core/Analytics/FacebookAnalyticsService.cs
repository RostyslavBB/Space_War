using Interfaces.Analytics;
using UnityEngine;
using Facebook.Unity;

namespace Core.Analytics
{
    public class FacebookAnalyticsService : IAnalyticsProvider
    {
        public void Initialize()
        {
            if(!FB.IsInitialized)
                FB.Init(OnInit);
            else
                FB.ActivateApp();
        }

        private void OnInit()
        {
            if(FB.IsInitialized)
            {
                FB.ActivateApp();

                Debug.Log("Facebook SDK Initialized");
            }
            else
            {
                Debug.LogError("Facebook SDK Init Failed");
            }
        }

        public void TrackEvent(string name)
        {
            Debug.Log($"FB event: {name}");

            FB.LogAppEvent(name);
        }

        public void TrackEvent(string name, int value)
        {
            Debug.Log($"FB event: {name} value: {value}");

            FB.LogAppEvent(name, value);
        }
    }
}