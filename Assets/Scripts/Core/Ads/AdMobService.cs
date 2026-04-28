using Interfaces.Ads;
using GoogleMobileAds.Api;
using UnityEngine;

namespace Core.Ads
{
    public class AdMobService : IAdsService
    {
        private InterstitialAd _interstitial;

        private const string TEST_AD_UNIT_ID = "ca-app-pub-9340361989235723~2286648954";

        public void Initialize()
        {
            MobileAds.Initialize(initStatus =>
            {
                Debug.Log("AdMob Initialized");

                LoadInterestitial();
            });
        }

        private void LoadInterestitial()
        {
            AdRequest request = new();

            InterstitialAd.Load(TEST_AD_UNIT_ID, request, (ad, error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Ad failed to load: " + error);

                    return;
                }

                Debug.Log("Ad loaded");

                _interstitial = ad;
            });
        }

        public void ShowInterestial()
        {
            if (_interstitial != null && _interstitial.CanShowAd())
            {
                _interstitial.Show();

                Debug.Log("Ad shown");

                LoadInterestitial();
            }
            else
            {
                Debug.LogWarning("Ad not ready");
            }
        }
    }
}