
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using Yodo1.MAS;

namespace MasWrapper
{
    public class MasRewardedAd : AdUnitLogic
    {
        public MasRewardedAd(IAdUnitKey key, IAdUnitEvents events,
            ICoroutineRunner coroutineRunner) : base(key, events, coroutineRunner)
        {
            
        }
        protected override bool IsAdReady() => Yodo1U3dRewardAd.GetInstance().IsLoaded();

        protected override void ShowAd() => Yodo1U3dRewardAd.GetInstance().ShowAd();

        public override void Load()
        {
            Yodo1U3dRewardAd.GetInstance().LoadAd();
        }
    }
}