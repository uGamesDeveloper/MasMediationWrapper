using System;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Environment;
using LittleBitGames.Environment.Ads;
using UnityEngine;
using UnityEngine.Scripting;
using Yodo1.MAS;


namespace MasWrapper
{
    public class MasInitializer : IMediationNetworkInitializer
    {
        private readonly AdsConfig _adsConfig;
        public event Action OnMediationInitialized;
        public bool IsInitialized { get; private set; }

        [Preserve]
        public MasInitializer(AdsConfig adsConfig)
        {
            _adsConfig = adsConfig;
        }
        public void Initialize()
        {
            Yodo1U3dMasCallback.OnSdkInitializedEvent += (success, error) =>
            {
                if (success)
                {
                    if (_adsConfig.Mode==ExecutionMode.Debug)
                        Yodo1U3dMas.ShowDebugger();
                    IsInitialized = true;
                    OnMediationInitialized?.Invoke();
                    Debug.Log("[Yodo1 Mas] The initialization has succeeded");
                }
                else
                {
                    Debug.LogError("[Yodo1 Mas] The initialization has failed with error " + error.ToString());
                }
            };
            Yodo1U3dMas.SetCCPA(false);
            Yodo1U3dMas.SetGDPR(true);
            Yodo1U3dMas.SetCOPPA(false);
            Yodo1U3dMas.InitializeMasSdk();
        }
    }
}
