namespace ASPNET6Middleware.Middleware
{
    /// <summary>
    /// 这个类显示了.NET 6 中中间件类的基本结构。
    /// </summary>
    public class LayoutMiddleware
    {
        private readonly RequestDelegate _next;

        // 中间件类必须包含一个公共构造函数，并且该构造函数必须具有 RequestDelegate 类型的参数。
        public LayoutMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // 这个方法是必需的，并且必须接受 HttpContext 类型的第一个参数。
        public async Task InvokeAsync(HttpContext context)
        {
            // 修改响应的代码

            await _next(context); // 这一行是必需的，否则管道中的下一个中间件将不会被调用。

            // 不修改响应的日志或其他代码
        }
    }
}
