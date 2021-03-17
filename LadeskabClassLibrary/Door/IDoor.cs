using System;

namespace LadeskabClassLibrary.Door
{
    public interface IDoor
    {
        public event EventHandler<DoorEventArgs> StateChanged;
        public bool DoorIsOpen { get; set; }
        public bool DoorLocked { get; set; }
        public void LockDoor();
        public void UnlockDoor();

    }
}