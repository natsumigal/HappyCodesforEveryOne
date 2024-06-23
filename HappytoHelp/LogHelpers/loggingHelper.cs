using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappytoHelp.LogHelpers
{
    public class loggingHelper
    {
        private string logFilePath;

        public loggingHelper(string logFilePath)
        {
            this.logFilePath = logFilePath;
            InitializeLogFile();
        }

        private void InitializeLogFile()
        {
            if (!File.Exists(logFilePath))
            {
                using (StreamWriter writer = File.CreateText(logFilePath))
                {
                    writer.WriteLine("Timestamp,LogLevel,Message");
                }
            }
        }

        public void Log(LogLevel level, string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp},{level},{message}";

            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine(logEntry);
            }
        }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
}

