using System;
using LittleBitGames.Ads.AdUnits;
using Yodo1.MAS;

namespace MasWrapper
{
    public class MasSdkInterEvents : IAdUnitEvents
    {
        public event Action<string, IAdInfo> OnAdRevenuePaid;
        public event Action<string, IAdInfo> OnAdLoaded;
        public event Action<string, IAdErrorInfo> OnAdLoadFailed;
        public event Action<string, IAdInfo> OnAdFinished;
        public event Action<string, IAdInfo> OnAdClicked;
        public event Action<string, IAdInfo> OnAdHidden;
        public event Action<string, IAdErrorInfo, IAdInfo> OnAdDisplayFailed;

        public MasSdkInterEvents()
        {
            Yodo1U3dInterstitialAd.GetInstance().OnAdLoadedEvent += (ad)=> OnAdLoaded?.Invoke(null,null);
            Yodo1U3dInterstitialAd.GetInstance().OnAdLoadFailedEvent +=(ad,error)=>
            {
                OnAdLoadFailed?.Invoke(null, error != null ? new AdErrorInfo(error) : null);
            };
            Yodo1U3dInterstitialAd.GetInstance().OnAdOpenFailedEvent += (ad, error) =>
            {
                OnAdDisplayFailed?.Invoke(null, error != null ? new AdErrorInfo(error) : null, null);
            };
            Yodo1U3dInterstitialAd.GetInstance().OnAdClosedEvent +=(ad)=>
            {
                OnAdFinished?.Invoke(null, null);
            };
            Yodo1U3dInterstitialAd.GetInstance().OnAdPayRevenueEvent += (ad, adValue) =>
            {
                OnAdRevenuePaid?.Invoke(null, new AdInfo("interstitial",adValue));
            };
        }
    }
}
