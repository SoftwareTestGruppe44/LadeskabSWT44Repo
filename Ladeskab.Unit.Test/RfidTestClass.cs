using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LadeskabClassLibrary.Scanner;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    public class RfidTestClass
    {
        private RfidScanner _uut;
        private ScanEventArgs _eventArgs;
        [SetUp]
        public void Setup()
        {
            //Setting eventArgs to null
            _eventArgs = null;

            //Initializing unit under test
            _uut = new RfidScanner();
            _uut.ScanEvent +=
                (o, args) =>
                {
                    _eventArgs = args;
                };
        }

        [Test]
        public void ScanId_NewIdDetected_EventCalled()
        {
            //Arrange
            _uut.ScanId(2);

            //Act
            //Assert
            Assert.That(_eventArgs, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ScanId_NewIdDetected_IdMatches(int id)
        {
            //Arrange
            _uut.ScanId(id);

            //Act
            //Assert
            Assert.That(_eventArgs.ScannedId, Is.EqualTo(id));
        }
    }
}
