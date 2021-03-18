using LadeskabClassLibrary.Door;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    [TestFixture()]
    public class DoorTest
    {
        private Door _door;
        private DoorEventArgs _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;
            _door = new Door();
            _door.StateChanged +=
                (o, args) =>
                {
                    _receivedEventArgs = args;
                };
        }
        [Test]
        public void UnlockDoor_DoorLockedChangesValue_IsEqualToFalse()
        {
            //arrange
            _door.LockDoor();
            //act
            _door.UnlockDoor();
            //assert
            Assert.AreEqual(false, _door.DoorLocked);
        }

        [Test]
        public void LockDoor_DoorLockedChangesValue_IsEqualToTrue()
        {
            //arrange
            
            //act
            _door.LockDoor();
            //assert
            Assert.AreEqual(true, _door.DoorLocked);
        }
        [Test]
        public void UnlockDoor_DoorLockedDoesNotChangeValue_IsEqualToFalse()
        {
            //arrange
            
            //act
            _door.UnlockDoor();
            //assert
            Assert.AreEqual(false, _door.DoorLocked);
        }
        [Test]
        public void DoorOpen_DoorIsOpenChangesState_EventFired()
        {
            // arrange
            
            //act
            _door.DoorOpen();
            //assert
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }
        [Test]
        public void DoorClose_DoorIsOpenChangesState_EventFired()
        {
            //arrange
            _door.DoorOpen();
            //act
            _door.DoorClose();
            //assert
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }
        [Test]
        public void DoorOpen_DoorIsOpenDoesNotChangeState_EventNotFired()
        {
            // arrange
            _door.DoorOpen();
            //act
            _receivedEventArgs = null;
            _door.DoorOpen();
            //assert
            Assert.That(_receivedEventArgs, Is.Null);
        }
        [Test]
        public void DoorClose_DoorIsOpenDoesNotChangeState_EventNotFired()
        {
            //arrange
            
            //act
            _door.DoorClose();
            //assert
            Assert.That(_receivedEventArgs, Is.Null);
        }
        [Test]
        public void DoorClose_DoorOpenIsSetToDoorIsOpen_IsEqualToFalse()
        {
            //arrange
            _door.DoorOpen();
            //act
            _door.DoorClose();
            //assert
            Assert.AreEqual(false, _receivedEventArgs.DoorOpen);
        }
        [Test]
        public void DoorOpen_DoorOpenIsSetToDoorIsOpen_IsEqualToTrue()
        {
            //arrange
            
            //act
            _door.DoorOpen();
            //assert
            Assert.AreEqual(true, _receivedEventArgs.DoorOpen);
        }


    }
}