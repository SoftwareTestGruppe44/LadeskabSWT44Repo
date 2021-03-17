using System;

namespace LadeskabClassLibrary.Door
{
    public class Door : IDoor
    {
       
        public event EventHandler<DoorEventArgs> StateChanged;
        public bool DoorIsOpen { get; set; }
        public bool DoorLocked { get; set; }

        public void DoorOpen()
        {
            if (DoorIsOpen == true) return;

            DoorIsOpen = true;
            OnStateChanged(new DoorEventArgs() { DoorOpen = DoorIsOpen });
        }


        public void DoorClose()
        {
            if (DoorIsOpen == false) return;
            DoorIsOpen = false;
            OnStateChanged(new DoorEventArgs() { DoorOpen = DoorIsOpen });

        }
        public void LockDoor()
        {
            if (DoorLocked == true) return;
            DoorLocked = true;
        }


        public void UnlockDoor()
        {
            if (DoorLocked == false) return;
            DoorLocked = false;

        }

        protected virtual void OnStateChanged(DoorEventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }
    }
}