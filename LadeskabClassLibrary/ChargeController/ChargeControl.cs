using System;
using LadeskabClassLibrary.USBCharger;

namespace LadeskabClassLibrary.ChargeController
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger usbCharger;

        //Constructor takes UsbCharger interface as input,
        //so ChargeControl knows which USBcharger is being worked on
        public ChargeControl(IUsbCharger iusb)
        {
            usbCharger = iusb;
        }
        public bool isConnected() //Checks UsbChargerSimulator if connected/Returns true/false
        {
            if (usbCharger.Connected) { return true; } 
            return false;
        }

        public void StartCharge()
        {
            usbCharger.StartCharge();
        }

        public void StopCharge()
        {
            usbCharger.StopCharge();
        }
    }
}