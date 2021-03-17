namespace LadeskabClassLibrary.MyConsole
{
    public class MyConsole : IMyConsole
    {
        public string _msg { private set; get; }
        public void WriteLine(string msg)
        {
            System.Console.WriteLine(msg);
            _msg = msg;
        }
    }
}