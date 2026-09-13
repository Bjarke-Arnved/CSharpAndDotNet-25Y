namespace Lektion03Opgave02;

public class LogProcessor
{
    // FEJL: 'LogHandler' er endnu ikke defineret!
    public delegate void LogHandler(string log, DateTime timeStamp);
    public void ProcessLogs(string[] logs, LogHandler handler)
    {
        foreach (var log in logs)
        {
            // Delegaten kaldes her med en streng og et DateTime-objekt
            handler(log, DateTime.Now);
        }
    }
}