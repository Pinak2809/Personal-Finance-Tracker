using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace PersonalFinanceTracker.Helpers
{
    public static class Logger
    {
        private static readonly string LogFile = "app.log";

        public static void Log(string message, 
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {Path.GetFileName(sourceFilePath)} | {memberName}:{sourceLineNumber} | {message}";
                File.AppendAllText(LogFile, logMessage + Environment.NewLine);
                System.Diagnostics.Debug.WriteLine(logMessage);
            }
            catch
            {
                // Fail silently if logging fails
                System.Diagnostics.Debug.WriteLine($"Failed to log message: {message}");
            }
        }
    }
}