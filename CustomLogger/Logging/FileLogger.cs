using System.Text;

namespace CustomLogger.Logging;

public class FileLogger : ILoggerDestination
{
    private readonly string _filePath;
    public LogLevel? LoggingLevel { get; init; }
    
    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }
    
    public FileLogger(string filePath, LogLevel level) : this(filePath)
    {
        LoggingLevel = level;
    }

    public void Log(string message)
    {
        using var fs = new FileStream(_filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
        var buffer = Encoding.Default.GetBytes(message);
        fs.Write(buffer, 0, buffer.Length);
        fs.WriteByte((byte)'\n');
    }
}