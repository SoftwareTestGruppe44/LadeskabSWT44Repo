using System;

namespace LadeskabClassLibrary.Door
{
    public interface IDoor
    {
        event EventHandler<DoorEventArgs> StateChanged;
        bool DoorIsOpen { get;}
        bool DoorLocked { get;}
        void LockDoor();
        void UnlockDoor();

    }
}