using System;

namespace LadeskabClassLibrary.Door
{
    public interface IDoor
    {
        public event EventHandler<DoorEventArgs> StateChanged;
        public bool DoorOpened { get; set; }
        public bool DoorClosed { get; set; }
        public void LockDoor(bool doorStateChanged);
        public void UnlockDoor(bool doorStateChanged);
    }
}