using LadeskabClassLibrary.Log;
using LadeskabClassLibrary.MyConsole;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    public class LogTest
    {
        private ILog _logger;
        private ILogger _fakeLogger;
        [SetUp]
        public void Setup()
        {
            _fakeLogger = Substitute.For<ILogger>();
            _logger = new LogFile(_fakeLogger);
        }

        [Test]
        public void LogDoorLocked_ReceivesAndCreateString_CallFakeLogger()
        {
            //Arrange
            _logger.LogDoorLocked(1);
            //Act
            //Assert
            _fakeLogger.ReceivedWithAnyArgs(1).WriteToFile(default);
        }

        [Test]
        public void LogDoorUnLocked_ReceivesAndCreateString_CallFakeLogger()
        {
            //Arrange
            _logger.LogDoorUnlocked(1);
            //Act
            //Assert
            _fakeLogger.ReceivedWithAnyArgs(1).WriteToFile(default);
        }
    }
}