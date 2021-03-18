using LadeskabClassLibrary;
using LadeskabClassLibrary.ChargeController;
using LadeskabClassLibrary.Door;
using LadeskabClassLibrary.Log;
using LadeskabClassLibrary.MyConsole;
using LadeskabClassLibrary.Scanner;
using LadeskabClassLibrary.UserInterface;
using NSubstitute;
using NSubstitute.Exceptions;
using NSubstitute.Routing.Handlers;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    public class StationControlTest
    {
        private IChargeControl _subChargeControl;
        private IDoor _subDoor;
        private IDisplay _subDisplay;
        private ILog _subLog;
        private IScanner _subScanner;
        private StationControl _stationControl;
        [SetUp]
        public void Setup()
        {
            _subChargeControl = Substitute.For<IChargeControl>();
            _subDoor = Substitute.For<IDoor>();
            _subScanner = Substitute.For<IScanner>();
            _subDisplay = Substitute.For<IDisplay>();
            _subLog = Substitute.For<ILog>();
            _subChargeControl = Substitute.For<IChargeControl>();
            _stationControl = new StationControl(_subChargeControl, _subDoor, _subScanner, _subDisplay, _subLog);
        }

        [Test]
        public void ConnectPhone_HdDisplay_CallConsoleConnectPhone()
        {
            //Arrange

            //Act
            _subDoor.StateChanged += Raise.EventWith(new DoorEventArgs() { DoorOpen = true });
            //Assert
            _subDisplay.Received(1).ConnectPhone();
        }

        [Test]
        public void ConnectPhone_HdDisplay_CallConsoleScanRFID()
        {
            //Arrange

            //Act
            _subDoor.StateChanged += Raise.EventWith(new DoorEventArgs() { DoorOpen = false });
            //Assert
            _subDisplay.Received(1).ScanRFID();
        }

        [Test]
        public void ConnectPhone_RFIDscanned_PhoneNotConnected()
        {
            //Arrange
            _subChargeControl.isConnected().Returns(false);
            //Act
            _subScanner.ScanEvent += Raise.EventWith(new ScanEventArgs() { ScannedId = 10 });
            //Assert
            _subDisplay.Received(1).ConnectionError();
        }
        
        [Test]
        public void ConnectPhone_RFIDscanned_DoorNotClosed()
        {
            //Arrange
            _subDoor.DoorIsOpen.Returns(true);
            _subChargeControl.isConnected().Returns(false);
            //Act
            _subScanner.ScanEvent += Raise.EventWith(new ScanEventArgs() { ScannedId = 10 });
            //Assert
            _subDisplay.Received(1).ConnectionError();
        }

        [Test]
        public void ConnectPhone_RFIDscanned_PhoneConnected()
        {
            //Arrange
            _subChargeControl.isConnected().Returns(true);
            //Act
            _subScanner.ScanEvent += Raise.EventWith(new ScanEventArgs() { ScannedId = 10 });
            //Assert
            _subDisplay.Received(1).Busy();
        }

        [Test]
        public void ConnectPhone_RFIDscannedWhenInUse_WrongID()
        {
            //Arrange
            _subChargeControl.isConnected().Returns(true);
            //Act
            _subScanner.ScanEvent += Raise.EventWith(new ScanEventArgs() { ScannedId = 10 });
            _subScanner.ScanEvent += Raise.EventWith(new ScanEventArgs() { ScannedId = 5 });
            //Assert
            _subDisplay.Received(1).RFIDError();
        }

        [Test]
        public void ConnectPhone_RFIDscannedWhenInUse_CorrectID()
        {
            //Arrange
            _subChargeControl.isConnected().Returns(true);
            //Act
            _subScanner.ScanEvent += Raise.EventWith(new ScanEventArgs() { ScannedId = 10 });
            _subScanner.ScanEvent += Raise.EventWith(new ScanEventArgs() { ScannedId = 10 });
            //Assert
            _subDisplay.Received(1).PhoneDone();
        }
    }
}