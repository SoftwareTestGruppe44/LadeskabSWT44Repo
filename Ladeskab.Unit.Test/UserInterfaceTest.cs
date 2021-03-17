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
        public void Test1()
        {
            //Arrange

            //Act
            _display.ConnectPhone();
            //Assert
            _myConsole.Received(1).WriteLine("Please connect your phone to the charger and close the door.");
        }
    }
}