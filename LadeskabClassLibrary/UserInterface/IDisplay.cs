namespace LadeskabClassLibrary.UserInterface
{
    public interface IDisplay
    {
        void ConnectPhone();
        void ScanRFID();
        void RFIDError();
        void ConnectionError();
        void Busy();
        void PhoneDone();
    }
}