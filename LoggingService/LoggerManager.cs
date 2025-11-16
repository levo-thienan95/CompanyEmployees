using Serilog;

namespace LoggingService;

public class LoggerManager : ILoggerManager
{
    private readonly ILogger _logger;

    public LoggerManager(ILogger logger)
    {
        _logger = logger;
    }

    public void LogDebug(string message)
    {
        _logger.Debug(message);
    }

    public void LogInformation(string message)
    {
        _logger.Information(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warning(message);
    }

    public void LogError(string message)
    {
        _logger.Error(message);
    }
}