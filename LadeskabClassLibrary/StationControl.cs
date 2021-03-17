using System;
using System.IO;
using LadeskabClassLibrary.ChargeController;
using LadeskabClassLibrary.Door;
using LadeskabClassLibrary.Log;
using LadeskabClassLibrary.Scanner;
using LadeskabClassLibrary.UserInterface;

namespace LadeskabClassLibrary
{
    public class StationControl
    {
        /* Region Content:
         * enum LadeskabState
         * LadeskabState _state;
         * IChargeControl _charger;
         * int _oldId;
         * IDoor _door;
         * IDisplay _display;
         * ILog _Log;
         */
        #region Propeties
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private IDisplay _display;
        private ILog _Log;
        
        #endregion

        public StationControl(IChargeControl charger, IDoor door, IDisplay display, ILog log)
        {
            _charger = charger;
            _door = door;
            _display = display;
            _Log = log;
        }

        /* Region content:
         * RfidDetected(object o, ScanEventArgs e)
         * DoorChanged(object o, DoorEventArgs e)
         */
        #region Handlers
        // method for event handler in RFIDscanner.
        private void RfidDetected(object o, ScanEventArgs e)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.isConnected())
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = e.ScannedId;
                        _Log.LogDoorLocked(e.ScannedId);
                        _display.Busy();
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.ConnectionError();
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (e.ScannedId == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();
                        _Log.LogDoorUnlocked(e.ScannedId);
                        _display.PhoneDone();
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.RFIDError();
                    }
                    break;
            }
        }

        // method for event handler in door.
        private void DoorChanged(object o, DoorEventArgs e)
        {
            if (e.DoorOpen)
            {
                _display.ConnectPhone();
            }
            else
            {
                _display.ScanRFID();
            }
        }

        #endregion

    }
}
