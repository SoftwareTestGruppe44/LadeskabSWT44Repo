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
            _chargeControl = Substitute.For<IChargeControl>();
            _usbCharger = Substitute.For<IUsbCharger>();
        }

        [Test]
        public void check_isConnected()
        {
            //Arrange
            _chargeControl.isConnected();
            //Act

            //Assert
            Assert.Pass();
        }

        [Test]
        public void check_startCharge()
        {
            //Arrange

            //Act
            _usbCharger.StartCharge();
            //Assert
            _usbCharger.Received(1).StartCharge();
        }

        [Test]
        public void check_stopCharge()
        {
            //Arrange

            //Act
            _usbCharger.StopCharge();
            //Assert
            _usbCharger.Received(1).StopCharge();
        }
    }
}