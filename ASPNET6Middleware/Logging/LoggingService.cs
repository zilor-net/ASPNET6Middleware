namespace ASPNET6Middleware.Logging
{
    public class LoggingService : ILoggingService
    {

        public void Log(LogLevel logLevel, string message)
        {
            // 日志具体实现省略
        }
    }

    public interface ILoggingService
    {
        public void Log(LogLevel level, string message);
    }
}
