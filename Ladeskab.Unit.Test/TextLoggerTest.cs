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
        private ILogger _logger;
        [SetUp]
        public void Setup()
        {
            _logger = new TextLogger();
        }

        //This test is for local use only. Jenkins cannot run
        //because it cannot access local files. This test write to the local 
        //log, and checks if it succesfully wrote to the log. 
        [Test]
        public void WriteToFile_WriteTestOnLastLineInFile_LastLineContainsTest()
        {
            ////Arrange
            ////Act
            //_logger.WriteToFile("test\n");
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Logger.txt";
            
            ////Assert
            //Assert.That(File.ReadLines(path).Last(), Is.EqualTo("test") );
        }
    }
}