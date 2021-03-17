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
            _door.DoorIsOpen = false;
            _door.StateChanged +=
                (o, args) =>
                {
                    _receivedEventArgs = args;
                };
        }
        [Test]
        public void UnlockDoor_DoorIsOpenChangesState_EventFired()
        {
            _door.UnlockDoor(_door.DoorIsOpen);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }
    }
}