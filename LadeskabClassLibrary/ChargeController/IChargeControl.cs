namespace LadeskabClassLibrary.ChargeController
{
    public interface IChargeControl
    {
        public bool isConnected();
        public void StartCharge();
        public void StopCharge();
    }
}