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
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
