using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Environment.Ads;

namespace MasWrapper
{
    public class MasServiceBuilder : IAdsServiceBuilder
    {
        private readonly AdsConfig _adsConfig;
        private readonly MasInitializer _initializer;
        
        private IAdUnit _inter, _rewarded, _banner;
        private MasSdkAdUnitsFactory _adUnitsFactory;

        public IMediationNetworkInitializer Initializer => _initializer;
        
        public MasServiceBuilder(AdsConfig adsConfig,ICoroutineRunner coroutineRunner)
        {
            _adsConfig = adsConfig;
            _initializer = new MasInitializer(adsConfig);
            _initializer.Initialize();            
            _adUnitsFactory = new MasSdkAdUnitsFactory(coroutineRunner);
        }

        

        public void QuickBuild()
        {
            if (_adsConfig.IsInter) 
                BuildInterAdUnit();
            if (_adsConfig.IsRewarded) 
                BuildRewardedAdUnit();
            if (_adsConfig.IsBanner) 
                BuildBannerAdUnit();
        }
        
        public void BuildInterAdUnit()
        {
            _inter = _adUnitsFactory.CreateInterAdUnit();
        }

        public void BuildRewardedAdUnit()
        {
            _rewarded = _adUnitsFactory.CreateRewardedAdUnit();
        }
        
        public void BuildBannerAdUnit()
        {
            _banner = _adUnitsFactory.CreateBannerAdUnit();
        }
        
        public IAdsService GetResult() => new AdsService(_initializer, _inter, _rewarded, _banner);
    }
}
