using LittleBitGames.Ads.AdUnits;
using UnityEngine;
using Yodo1.MAS;


namespace MasWrapper
{
    public class AdErrorInfo : IAdErrorInfo
    {
        public string Message { get; }
        public int MediatedNetworkErrorCode { get; }
        public string MediatedNetworkErrorMessage { get; }

        public AdErrorInfo(Yodo1U3dAdError adError)
        {
            MediatedNetworkErrorCode = adError.Code;
            MediatedNetworkErrorMessage = adError.Message;
            Debug.LogError(MediatedNetworkErrorMessage);
        }
    }
}