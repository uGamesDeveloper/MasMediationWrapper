using System;
using LittleBitGames.Ads.AdUnits;
using Yodo1.MAS;

namespace MasWrapper
{
    public class AdInfo : IAdInfo
    {
        public string AdUnitIdentifier { get; }
        public string AdFormat { get; }
        public string NetworkName { get; }
        public string NetworkPlacement { get; }
        public string Placement { get; }
        public string CreativeIdentifier { get; }
        public double Revenue { get; }
        public string RevenuePrecision { get; }
        public string DspName { get; }

        public AdInfo(string adFormat,Yodo1U3dAdValue adValue)
        {
            AdUnitIdentifier = "Undefined";
            AdFormat = adFormat;
            NetworkName = adValue.NetworkName;
            NetworkPlacement = "Undefined";
            Placement = "Undefined";
            CreativeIdentifier = "Undefined";
            Revenue = adValue.Revenue;
            RevenuePrecision = adValue.RevenuePrecision;
            DspName = "Undefined";
        }
    }
    
    
}