using System;

namespace LadeskabClassLibrary.Door
{
    public class Door : IDoor
    {
        // event handler based on DoorEventArgs
        public event EventHandler<DoorEventArgs> StateChanged;
        // Properties
        public bool DoorIsOpen { get; private set; }
        public bool DoorLocked { get; private set; }

        // constructor with defautl values of properties
        public Door()
        {
            DoorIsOpen = false;
            DoorLocked = false;
        }

        // Method to open door
        public void DoorOpen()
        {
            if (DoorIsOpen == true) return;
            DoorIsOpen = true;
            OnStateChanged(new DoorEventArgs() { DoorOpen = DoorIsOpen });
        }
        // Method to close door
        public void DoorClose()
        {
            if (DoorIsOpen == false) return;
            DoorIsOpen = false;
            OnStateChanged(new DoorEventArgs() { DoorOpen = DoorIsOpen });
        }
        // Method to lock door
        public void LockDoor()
        {
            if (DoorLocked == true || DoorIsOpen == true) return;
            DoorLocked = true;
        }
        // Method to unlock door
        public void UnlockDoor()
        {
            if (DoorLocked == false || DoorIsOpen == true) return;
            DoorLocked = false;
        }
        // Raise event
        protected virtual void OnStateChanged(DoorEventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }
    }
}