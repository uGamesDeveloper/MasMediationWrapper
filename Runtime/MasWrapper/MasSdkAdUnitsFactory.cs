using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using MasWrapper;
using Yodo1.MAS;

namespace LittleBitGames.Ads
{
    internal class MasSdkAdUnitsFactory
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public MasSdkAdUnitsFactory(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public IAdUnit CreateInterAdUnit() =>
            new MasInterAd(null, new MasSdkInterEvents(), _coroutineRunner);

        public IAdUnit CreateRewardedAdUnit() =>
            new MasRewardedAd(null, new MasSdkRewardAdEvents(), _coroutineRunner);

        public IAdUnit CreateBannerAdUnit()
        {
            Yodo1U3dBannerAdView bannerAdView = new Yodo1U3dBannerAdView(Yodo1U3dBannerAdSize.Banner,
                Yodo1U3dBannerAdPosition.BannerBottom | Yodo1U3dBannerAdPosition.BannerHorizontalCenter);
            return new MasBannerAd(null, new MasSdkBannerAdEvents(bannerAdView), _coroutineRunner,bannerAdView);
        }
    }
}