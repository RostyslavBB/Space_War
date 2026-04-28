using Interfaces.Ads;
using Zenject;

namespace Core.Ads
{
    public class AdsInitializer : IInitializable
    {
        private readonly IAdsService _adsService;

        public AdsInitializer(IAdsService adsService)
        {
            _adsService = adsService;
        }

        public void Initialize()
        {
            _adsService.Initialize();
        }
    }
}