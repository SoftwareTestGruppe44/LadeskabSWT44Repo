using System;
using LadeskabClassLibrary.MyConsole;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    public class MyConsoleTest
    {
        private MyConsole _myConsole;
        [SetUp]
        public void Setup()
        {
            _myConsole = new MyConsole();
        }

        [Test]
        public void WriteLine_MyConsole_getTheSetMsg()
        {
            //Arrange

            //Act
            _myConsole.WriteLine("test");
            //Assert
            Assert.AreEqual(_myConsole._msg, "test");
        }


    }
}