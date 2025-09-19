using System;
using LittleBitGames.Ads.AdUnits;
using Yodo1.MAS;

namespace MasWrapper
{
    public class MasSdkBannerAdEvents : IAdUnitEvents
    {
        public event Action<string, IAdInfo> OnAdRevenuePaid;
        public event Action<string, IAdInfo> OnAdLoaded;
        public event Action<string, IAdErrorInfo> OnAdLoadFailed;
        public event Action<string, IAdInfo> OnAdFinished;
        public event Action<string, IAdInfo> OnAdClicked;
        public event Action<string, IAdInfo> OnAdHidden;
        public event Action<string, IAdErrorInfo, IAdInfo> OnAdDisplayFailed;

        public MasSdkBannerAdEvents(Yodo1U3dBannerAdView bannerAdView)
        {
            bannerAdView.OnAdLoadedEvent += (ad)=> OnAdLoaded?.Invoke(null,null);
            bannerAdView.OnAdFailedToLoadEvent +=(ad,error)=>
            {
                OnAdLoadFailed?.Invoke(null, error != null ? new AdErrorInfo(error) : null);
            };
            bannerAdView.OnAdFailedToOpenEvent += (ad, error) =>
            {
                OnAdDisplayFailed?.Invoke(null, error != null ? new AdErrorInfo(error) : null, null);
            };
            bannerAdView.OnAdClosedEvent +=(ad)=>
            {
                OnAdFinished?.Invoke(null, null);
            };
            bannerAdView.OnAdPayRevenueEvent += (ad, adValue) =>
            {
                OnAdRevenuePaid?.Invoke(null, new AdInfo("banner",adValue));
            };
        }
    }
}