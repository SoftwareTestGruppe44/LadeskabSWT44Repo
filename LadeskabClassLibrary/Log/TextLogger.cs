﻿using System;
using System.IO;

namespace LadeskabClassLibrary.Log
{
    public class TextLogger : ILogger
    {
        public void WriteToFile(string text)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.AppendAllText(Path.Combine(path, "Logger.txt"), text);
        }
    }
}