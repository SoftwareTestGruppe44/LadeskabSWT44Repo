using System;
using LadeskabClassLibrary.MyConsole;

namespace LadeskabClassLibrary.UserInterface
{
    public class HdDisplay : IDisplay
    {
        private IMyConsole _myConsole;

        public HdDisplay(IMyConsole myConsole)
        {
            _myConsole = myConsole;
        }
        public void ConnectPhone()
        {
            _myConsole.WriteLine("Please connect your phone to the charger and close the door.");
        }

        public void ScanRFID()
        {
            _myConsole.WriteLine("Please scan your RFID tag.");
        }

        public void RFIDError()
        {
            _myConsole.WriteLine("Your RFID-tag doesn't match the owner of this locker.");    
        }

        public void ConnectionError()
        {
            _myConsole.WriteLine("Your phone doesn't seem to be connected. Please check the cabel and close the door again.");
        }

        public void Busy()
        {
            _myConsole.WriteLine("Your phone is now charging. This charging locker is therefore now busy. If it is your locker scan your RFID tag to open.");
        }

        public void PhoneDone()
        {
            _myConsole.WriteLine("Take your phone and close the door.");
        }

        public void CurrentChargingValue(double value)
        {
            _myConsole.WriteLine($"The phone is now at value {value}");
        }
    }
}