using System;
using LadeskabClassLibrary.USBCharger;
using static LadeskabClassLibrary.USBCharger.IUsbCharger;

namespace LadeskabClassLibrary.ChargeController
{
    public class ChargeControl : IChargeControl
    {
        private UsbChargerSimulator usbCharger = new UsbChargerSimulator();
        public bool isConnected()
        {
            if (usbCharger.Connected == true)
            {
                return true;
            }
            else
            {
                return false;
            }
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