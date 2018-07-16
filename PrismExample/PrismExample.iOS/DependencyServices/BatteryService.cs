using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using PrismExample.DependencyServices;
using UIKit;

namespace PrismExample.iOS.DependencyServices
{
    public class BatteryService : IBatteryService
    {
        public string GetBatteryStatus()
        {
            switch (UIDevice.CurrentDevice.BatteryState)
            {
                case UIDeviceBatteryState.Charging:
                    return "Charging";
                case UIDeviceBatteryState.Full:
                    return "Full";
                case UIDeviceBatteryState.Unplugged:
                    return "Discharging";
                default:
                    return "Unknown";
            }
        }
    }
}