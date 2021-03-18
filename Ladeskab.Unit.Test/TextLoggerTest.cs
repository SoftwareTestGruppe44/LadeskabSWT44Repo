using System;
using System.IO;
using System.Linq;
using LadeskabClassLibrary.Log;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    public class TextLoggerTest
    {
        ILogger _logger = new TextLogger();
        private ILog _fakeLog;
        [SetUp]
        public void Setup()
        {
            _fakeLog = Substitute.For<ILog>();
        }

        [Test]
        public void WriteToFile_WriteTestOnLastLineInFile_LastLineContainsTest()
        {
            //Arrange
            //Act
            _logger.WriteToFile("test\n");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Logger.txt";
            
            //Assert
            Assert.That(File.ReadLines(path).Last(), Is.EqualTo("test") );
        }
    }
}