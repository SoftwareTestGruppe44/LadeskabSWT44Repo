using LadeskabClassLibrary;
using LadeskabClassLibrary.ChargeController;
using LadeskabClassLibrary.Door;
using LadeskabClassLibrary.Log;
using LadeskabClassLibrary.MyConsole;
using LadeskabClassLibrary.Scanner;
using LadeskabClassLibrary.UserInterface;
using NSubstitute;
using NSubstitute.Exceptions;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    public class StationControlTest
    {
        private IChargeControl _chargeControl;
        private Door _testDoor;
        private IDoor _door;
        private IDisplay _display;
        private ILog _log;
        private IScanner _scanner;
        private StationControl _stationControl;
        [SetUp]
        public void Setup()
        {
            _chargeControl = Substitute.For<IChargeControl>();
            _testDoor = Substitute.For<Door>();
            _door = _testDoor;
            _scanner = Substitute.For<IScanner>();
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _chargeControl = Substitute.For<IChargeControl>();
            _stationControl = new StationControl(_chargeControl, _door, _scanner, _display, _log);
        }

        [Test]
        public void ConnectPhone_HdDisplay_CallConsoleWriteLine()
        {
            //Arrange
            //_testDoor.DoorOpen();
            //Act
            
            //Assert
            //_display.Received(1).ConnectPhone();
        }
    }
}