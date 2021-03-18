using System;
using System.IO;
using LadeskabClassLibrary.MyConsole;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    public class MyConsoleTest
    {
        private MyConsole _myConsole;
        private StringWriter _stringWriter;

        [SetUp]
        public void Setup()
        {
            _stringWriter = new StringWriter();
            System.Console.SetOut(_stringWriter);
            _myConsole = new MyConsole();

        }

        [Test]
        public void WriteLine_MyConsole_getTheSetMsg()
        {
            //Arrange

            //Act
            _myConsole.WriteLine("test");
            var consoleText = _stringWriter.ToString();
            //Assert
            Assert.AreEqual("test\r\n", consoleText);
        }
    }
}