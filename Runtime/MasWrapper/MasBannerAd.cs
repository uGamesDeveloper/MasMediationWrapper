using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using Yodo1.MAS;

namespace MasWrapper
{
    public class MasBannerAd: AdUnitLogic
    {
        private readonly Yodo1U3dBannerAdView _bannerAdView;

        public MasBannerAd(IAdUnitKey key, IAdUnitEvents events,
            ICoroutineRunner coroutineRunner,Yodo1U3dBannerAdView bannerAdView) : base(key, events, coroutineRunner)
        {
            _bannerAdView = bannerAdView;
        }
        protected override bool IsAdReady() => _bannerAdView != null;
        protected override void ShowAd() => _bannerAdView?.Show();
        public override void Load()
        {
            _bannerAdView.LoadAd();
        }

    }
}