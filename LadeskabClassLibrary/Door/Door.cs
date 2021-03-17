using System;

namespace LadeskabClassLibrary.Door
{
    public class Door : IDoor
    {
       
        public event EventHandler<DoorEventArgs> StateChanged;
        public bool DoorIsOpen { get; set; }

        public void LockDoor(bool doorStateChanged)
        {
            if (DoorIsOpen == true) return;
            OnStateChanged(new DoorEventArgs() {DoorOpen = doorStateChanged});
            DoorIsOpen = false;
        }


        public void UnlockDoor(bool doorStateChanged)
        {
            if (DoorIsOpen != true) return;
            OnStateChanged(new DoorEventArgs() { DoorOpen = doorStateChanged });
            DoorIsOpen = true;
        }

        protected virtual void OnStateChanged(DoorEventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }
    }
}