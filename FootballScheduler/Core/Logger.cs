using System;
using System.IO;

namespace CORE
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

        private readonly string _logFilePath;

        public static Logger Instance => _instance.Value;

        private Logger()
        {
            var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            Directory.CreateDirectory(logDirectory);

            _logFilePath = Path.Combine(logDirectory, $"log_{DateTime.Now:yyyyMMdd}.txt");
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";


            try
            {
                File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Logger] Không thể ghi file log: {ex.Message}");
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
