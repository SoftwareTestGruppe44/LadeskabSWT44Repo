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
        public void check_isConnected_TrueFalse(bool connected)
        {
            //Arrange
            
            //Act
            _usbSimulator.SimulateConnected(connected);
            var connection = _chargeControl.isConnected();
           
            //Assert
            Assert.AreEqual(connected, connection);
        }

        [Test]
        public void ChargeControl_StartCharge_Calls_UsbCharger_StartCharge()
        {
            //Arrange

            //Act
            _chargeControl.StartCharge();
            //Assert
            _usbCharger.Received(1).StartCharge();
        }

        [Test]
        public void ChargeControl_StopCharge_Calls_UsbCharger_StopCharge()
        {
            //Arrange

            //Act
            _chargeControl.StopCharge();
            //Assert
            _usbCharger.Received(1).StopCharge();
        }
    }
}