using System;
using LadeskabClassLibrary;
using LadeskabClassLibrary.ChargeController;
using LadeskabClassLibrary.Door;
using LadeskabClassLibrary.Log;
using LadeskabClassLibrary.MyConsole;
using LadeskabClassLibrary.Scanner;
using LadeskabClassLibrary.USBCharger;
using LadeskabClassLibrary.UserInterface;

namespace LadeskabApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            MyConsole myConsole = new MyConsole();
            HdDisplay display = new HdDisplay(myConsole);
            UsbChargerSimulator usbCharger = new UsbChargerSimulator();
            ChargeControl chargeControl = new ChargeControl(usbCharger, display);
            Door door = new Door();
            TextLogger textLogger = new TextLogger();
            LogFile logFile = new LogFile(textLogger);
            RfidScanner scanner = new RfidScanner();
            
            StationControl stationControl = new StationControl(chargeControl, door, scanner, display, logFile);
            
            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("E: Exit \nO: Open\nC: Close\nS: Scan RFID");
                System.Console.WriteLine("Enter: E, O, C, S: ");
                input = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.DoorOpen();
                        break;

                    case 'C':
                        door.DoorClose();
                        break;

                    case 'S':
                        System.Console.WriteLine("Enter: RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        scanner.ScanId(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}
