using System;

namespace LadeskabClassLibrary.Scanner
{
    public interface IScanner
    {
        //int ScannedId { get; }

        event EventHandler<ScanEventArgs> ScanEvent;

        void ScanId(int id);
    }
}