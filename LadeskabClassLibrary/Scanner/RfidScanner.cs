using System;

namespace LadeskabClassLibrary.Scanner
{
    public class RfidScanner : IScanner
    {
        //public int ScannedId { get; }
        public event EventHandler<ScanEventArgs> ScanEvent;
        public void ScanId(int id)
        {
            if (id < 1) return;
            RfidScanned(new ScanEventArgs(){ ScannedId = id});   
        }

        private void RfidScanned(ScanEventArgs e)
        {
            ScanEvent?.Invoke(this, e);
        }
    }
}