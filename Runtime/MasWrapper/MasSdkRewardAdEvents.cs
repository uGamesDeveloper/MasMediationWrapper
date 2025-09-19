using System;
using LittleBitGames.Ads.AdUnits;
using Yodo1.MAS;

namespace MasWrapper
{
    public class MasSdkRewardAdEvents : IAdUnitEvents
    {
        public event Action<string, IAdInfo> OnAdRevenuePaid;
        public event Action<string, IAdInfo> OnAdLoaded;
        public event Action<string, IAdErrorInfo> OnAdLoadFailed;
        public event Action<string, IAdInfo> OnAdFinished;
        public event Action<string, IAdInfo> OnAdClicked;
        public event Action<string, IAdInfo> OnAdHidden;
        public event Action<string, IAdErrorInfo, IAdInfo> OnAdDisplayFailed;

        public MasSdkRewardAdEvents()
        {
            Yodo1U3dRewardAd.GetInstance().OnAdLoadedEvent += (ad)=> OnAdLoaded?.Invoke(null,null);
            Yodo1U3dRewardAd.GetInstance().OnAdLoadFailedEvent +=(ad,error)=>
            {
                OnAdLoadFailed?.Invoke(null, error != null ? new AdErrorInfo(error) : null);
            };
            Yodo1U3dRewardAd.GetInstance().OnAdOpenFailedEvent += (ad, error) =>
            {
                OnAdDisplayFailed?.Invoke(null, error != null ? new AdErrorInfo(error) : null, null);
            };
            Yodo1U3dRewardAd.GetInstance().OnAdClosedEvent +=(ad)=>
            {
                OnAdFinished?.Invoke(null, null);
            };
            Yodo1U3dRewardAd.GetInstance().OnAdPayRevenueEvent += (ad, adValue) =>
            {
                OnAdRevenuePaid?.Invoke(null, new AdInfo("rewarded",adValue));
            };
        }
    }
}