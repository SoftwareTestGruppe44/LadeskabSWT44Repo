using System;
using LadeskabClassLibrary.USBCharger;
using LadeskabClassLibrary.UserInterface;

namespace LadeskabClassLibrary.ChargeController
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger _usbCharger;
        private IDisplay _display;
        private bool _fullyCharged = false;

        //Constructor takes _usbCharger interface as input,
        //so ChargeControl knows which _usbCharger is being worked on
        public ChargeControl(IUsbCharger iusb, IDisplay display)
        {
            _usbCharger = iusb;
            _usbCharger.CurrentValueEvent += ChargingValueChanged;
            _display = display;
        }
        public bool isConnected() //Checks _usbChargerSimulator if connected/Returns true/false
        {
            if (_usbCharger.Connected) { return true; } 
            return false;
        }

        public void StartCharge()
        {
            _usbCharger.StartCharge();
        }

        public void StopCharge()
        {
            _usbCharger.StopCharge();
        }

        public void ChargingValueChanged(object o, CurrentEventArgs e)
        {
            double val = ((500 - 2.5) - (e.Current-2.5))/(500-2.5) * 100;

            if (val % 5 == 0 && !_fullyCharged)
            {
                _display.CurrentChargingValue(val);
            }

            if (val == 100)
            {
                _fullyCharged = true;
            }
        }
    }
}