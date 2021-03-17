using System.CodeDom.Compiler;

namespace LadeskabClassLibrary.Log
{
    public interface ILog
    {
        void LogDoorLocked(int id);
        void LogDoorUnlocked(int id);
    }
}