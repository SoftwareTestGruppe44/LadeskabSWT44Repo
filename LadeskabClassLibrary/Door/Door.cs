using System;

namespace LadeskabClassLibrary.Door
{
    public class Door : IDoor
    {
       
        public event EventHandler<DoorEventArgs> StateChanged;
        public bool DoorOpened { get; set; }
        public bool DoorClosed { get; set; }
        public void LockDoor(bool doorStateChanged)
        {
            if (DoorClosed == true) 
            {
                OnStateChanged(new DoorEventArgs() {DoorOpen = doorStateChanged});
                DoorClosed = false;
                DoorOpened = true;
            }
        }


        public void UnlockDoor(bool doorStateChanged)
        {
            if (DoorOpened != true)
            {
                OnStateChanged(new DoorEventArgs() { DoorOpen = doorStateChanged });
                DoorOpened = false;
                DoorClosed = true;
            }
        }

        protected virtual void OnStateChanged(DoorEventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }
    }
}