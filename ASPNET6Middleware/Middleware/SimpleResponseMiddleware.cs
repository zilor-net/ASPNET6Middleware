namespace ASPNET6Middleware.Middleware
{
    /// <summary>
    /// 这个类将向响应体添加一个简单的文本行。
    /// </summary>
    public class SimpleResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello Dear Readers!");
        }
    }
}
