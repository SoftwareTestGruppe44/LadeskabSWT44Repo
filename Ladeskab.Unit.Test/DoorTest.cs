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
        public void UnlockDoor_DoorIsOpenChangesState_EventFired()
        {
            //arrange
            _door.DoorIsOpen = false;
            //act
            _door.UnlockDoor(_door.DoorIsOpen);
            //assert
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        [Test]
        public void LockDoor_DoorIsOpenChangesState_EventFired()
        {
            //arrange
            _door.DoorIsOpen = true;
            //act
            _door.LockDoor(_door.DoorIsOpen);
            //assert
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }
        [Test]
        public void UnlockDoor_DoorIsOpenChangesState_EventNotFired()
        {
            // arrange
            _door.DoorIsOpen = true;
            //act
            _door.UnlockDoor(_door.DoorIsOpen);
            //assert
            Assert.That(_receivedEventArgs, Is.Null);
        }
        [Test]
        public void LockDoor_DoorIsOpenChangesState_EventNotFired()
        {
            //arrange
            _door.DoorIsOpen = false;
            //act
            _door.LockDoor(_door.DoorIsOpen);
            //assert
            Assert.That(_receivedEventArgs, Is.Null);
        }
    }
}