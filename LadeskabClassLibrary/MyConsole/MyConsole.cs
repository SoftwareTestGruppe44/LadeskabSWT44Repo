namespace LadeskabClassLibrary.MyConsole
{
    public class MyConsole : IMyConsole
    {
        public void WriteLine(string msg)
        {
            System.Console.WriteLine(msg);
        }
    }
}