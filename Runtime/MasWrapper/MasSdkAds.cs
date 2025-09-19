using LittleBitGames.Ads;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Environment.Ads;
using UnityEngine.Scripting;

namespace MasWrapper
{
    public class MasSdkAds
    {
        private readonly MasServiceBuilder _builder;
        private readonly AdsConfig _adsConfig;
        private readonly ICreator _creator;
        private IAdsService _adsService;

        public IAdsService AdsService => _adsService;
        public MasServiceBuilder Builder => _builder;

        [Preserve]
        public MasSdkAds(ICreator creator,AdsConfig adsConfig)
        {
            _creator = creator;
            _builder = creator.Instantiate<MasServiceBuilder>(adsConfig);
        }
        
        public IAdsService CreateAdsService()
        {
            _builder.QuickBuild();
            _adsService = _builder.GetResult();
            foreach (var adUnit in _adsService.AdUnits)
            {
                adUnit?.Load();
            }
            
            return _adsService;
        }

        public IMediationNetworkAnalytics CreateAnalytics() => _creator.Instantiate<MasSdkAnalytics>(_adsService);
    }
}