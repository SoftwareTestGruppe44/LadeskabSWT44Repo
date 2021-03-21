using System.Runtime.CompilerServices;
using LadeskabClassLibrary.MyConsole;
using LadeskabClassLibrary.UserInterface;
using NUnit.Framework;
using NSubstitute;

namespace Ladeskab.Unit.Test
{
    public class UserInterfaceTest
    {
        private IMyConsole _myConsole;
        private HdDisplay _display;
        [SetUp]
        public void Setup()
        {
            _myConsole = Substitute.For<IMyConsole>();
            _display = new HdDisplay(_myConsole);
        }

        [Test]
        public void HdDisplay_ConnectPhone_CallConsoleWriteLine()
        {
            //Arrange

            //Act
            _display.ConnectPhone();
            //Assert
            _myConsole.Received(1).WriteLine("Please connect your phone to the charger and close the door.");
        }

        [Test]
        public void HdDisplay_ScanRFID_CallConsoleWriteLine()
        {
            //Arrange

            //Act
            _display.ScanRFID();
            //Assert
            _myConsole.Received(1).WriteLine("Please scan your RFID tag.");
        }

        [Test]
        public void HdDisplay_RFIDError_CallConsoleWriteLine()
        {
            //Arrange

            //Act
            _display.RFIDError();
            //Assert@"
            _myConsole.Received(1).WriteLine("Your RFID-tag doesn't match the owner of this locker.");
        }

        [Test]
        public void HdDisplay_ConnectionError_CallConsoleWriteLine()
        {
            //Arrange

            //Act
            _display.ConnectionError();
            //Assert
            _myConsole.Received(1).WriteLine("Your phone doesn't seem to be connected. Please check the cabel and close the door again.");
        }

        [Test]
        public void HdDisplay_Busy_CallConsoleWriteLine()
        {
            //Arrange

            //Act
            _display.Busy();
            //Assert
            _myConsole.Received(1).WriteLine("Your phone is now charging. This charging locker is therefore now busy. If it is your locker scan your RFID tag to open.");
        }
        [Test]
        public void HdDisplay_PhoneDone_CallConsoleWriteLine()
        {
            //Arrange

            //Act
            _display.PhoneDone();
            //Assert
            _myConsole.Received(1).WriteLine("Take your phone and close the door.");
        }

        [TestCase(0)]
        [TestCase(25.5)]
        [TestCase(50)]
        [TestCase(100)]
        public void HdDisplay_CurrentCharge_CallConsoleWriteLine(double value)
        {
            //Arrange

            //Act
            _display.CurrentChargingValue(value);
            //Assert
            _myConsole.Received(1).WriteLine($"The phone battery level is at {value}%");
        }
    }
}