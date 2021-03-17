namespace LadeskabClassLibrary.ChargeController
{
    public interface IChargeControl
    {
        public bool isConnected();
        public void startCharge();
        public void stopCharge();
    }
}