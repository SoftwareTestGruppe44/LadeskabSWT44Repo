using LadeskabClassLibrary.ChargeController;
using LadeskabClassLibrary.USBCharger;
using NUnit.Framework;
using NSubstitute;

namespace Ladeskab.Unit.Test
{
    public class ChargeControlTests
    {
        private IChargeControl _chargeControl;
        private IUsbCharger _usbCharger;
        private UsbChargerSimulator _usbSimulator;
        [SetUp]
        public void Setup()
        {
            _usbSimulator = Substitute.For<UsbChargerSimulator>();
            _usbCharger = _usbSimulator;
            _chargeControl = new ChargeControl(_usbCharger);
            
        }

        
        [TestCase(true)]
        [TestCase(false)]
        public void check_isConnected(bool connected)
        {
            //Arrange
            
            //Act
            _usbSimulator.SimulateConnected(connected);
            var connection = _chargeControl.isConnected();
           
            //Assert
            Assert.AreEqual(connected, connection);
        }

        [Test]
        public void check_startCharge()
        {
            //Arrange

            //Act
            _chargeControl.StartCharge();
            //Assert
            _usbCharger.Received(1).StartCharge();
            
        }

        [Test]
        public void check_stopCharge()
        {
            //Arrange

            //Act
            _chargeControl.StopCharge();
            //Assert
            _usbCharger.Received(1).StopCharge();
        }
    }
}