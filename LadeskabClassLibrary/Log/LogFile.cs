using System;

namespace LadeskabClassLibrary.Log
{
    public class LogFile : ILog
    {
        private readonly ILogger _logger;
        public LogFile(ILogger logger)
        {
            _logger = logger;
        }
        public void LogDoorLocked(int id)
        {
            var textToLog = "Ladeskab locked by RFID: " + id.ToString() + ", at time: " + DateTime.Now.ToString() + "\n";
            _logger.WriteToFile(textToLog);
        }

        public void LogDoorUnlocked(int id)
        {
            var textToLog = "Ladeskab unlocked by RFID: " + id.ToString() + ", at time: " + DateTime.Now.ToString() + "\n";
            _logger.WriteToFile(textToLog);
        }
    }
}