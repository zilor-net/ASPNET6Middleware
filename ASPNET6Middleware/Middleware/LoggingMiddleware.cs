using ASPNET6Middleware.Logging;

namespace ASPNET6Middleware.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingService _logger;

        public LoggingMiddleware(RequestDelegate next, ILoggingService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 记录传入的请求路径
            _logger.Log(LogLevel.Information, context.Request.Path);

            // 调用管道中的下一个中间件
            await _next(context);

            // 获得唯一响应头
            var uniqueResponseHeaders 
                = context.Response.Headers
                                  .Select(x => x.Key)
                                  .Distinct();

            // 记录响应头名称
            _logger.Log(LogLevel.Information, string.Join(", ", uniqueResponseHeaders));
        }
    }
}
