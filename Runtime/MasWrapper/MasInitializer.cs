using System;

using LittleBitGames.Environment.Ads;
using UnityEngine;
using Yodo1.MAS;

namespace MasWrapper
{
    public class MasInitializer : IMediationNetworkInitializer
    {
        public event Action OnMediationInitialized;
        public bool IsInitialized { get; private set; }
        public void Initialize()
        {
            Yodo1U3dMasCallback.OnSdkInitializedEvent += (success, error) =>
            {
                if (success)
                {
                    IsInitialized = true;
                    Debug.Log("[Yodo1 Mas] The initialization has succeeded");
                }
                else
                {
                    Debug.LogError("[Yodo1 Mas] The initialization has failed with error " + error.ToString());
                }
            };
            Yodo1U3dMas.InitializeMasSdk();
        }
    }
}