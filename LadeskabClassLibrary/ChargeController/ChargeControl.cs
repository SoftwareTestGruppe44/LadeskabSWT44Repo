using System;
using LadeskabClassLibrary.USBCharger;

namespace LadeskabClassLibrary.ChargeController
{
    public class ChargeControl : IChargeControl
    {
        private UsbChargerSimulator usbCharger = new UsbChargerSimulator();
        public bool isConnected()
        {
            if (usbCharger.Connected) { return true; } //Checks UsbChargerSimulator if connected
            return false;
        }

        public void startCharge()
        {
            usbCharger.StartCharge();
        }

        public void stopCharge()
        {
            usbCharger.StopCharge();
        }
    }
}