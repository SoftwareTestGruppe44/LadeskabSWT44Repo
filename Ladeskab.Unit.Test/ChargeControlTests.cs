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
        
        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();
            _chargeControl = new ChargeControl(_usbCharger);
        }

        
        [TestCase(true)]
        [TestCase(false)]
        public void isConnected_Returns_TrueOrFalse(bool setConnection)
        {
            //Arrange
            _usbCharger.Connected.Returns(setConnection);
            //Act
            var connection = _chargeControl.isConnected();
           
            //Assert
            Assert.AreEqual(setConnection, connection);
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