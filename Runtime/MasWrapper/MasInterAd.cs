using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using Yodo1.MAS;

namespace MasWrapper
{
    public class MasInterAd: AdUnitLogic
    {

        public MasInterAd(IAdUnitKey key, IAdUnitEvents events, ICoroutineRunner coroutineRunner) : base(key, events, coroutineRunner)
        {
            Yodo1U3dInterstitialAd.GetInstance().LoadAd();
        }
        protected override bool IsAdReady() => Yodo1U3dInterstitialAd.GetInstance().IsLoaded();

        protected override void ShowAd() => Yodo1U3dInterstitialAd.GetInstance().ShowAd();

        public override void Load()
        {
            Yodo1U3dInterstitialAd.GetInstance().LoadAd();
        }
    }
}