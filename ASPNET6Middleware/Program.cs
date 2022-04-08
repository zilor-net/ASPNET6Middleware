using ASPNET6Middleware.Extensions;
using ASPNET6Middleware.Logging;
using ASPNET6Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 向容器添加服务。
builder.Services.AddRazorPages();
builder.Services.AddTransient<ILoggingService, LoggingService>();

var app = builder.Build();


// 配置 HTTP 请求管道。
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// 向管道中添加中间件的最基本方法是使用 Run() 方法。
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello Dear Readers!");
//});

// 我们可以添加自定义中间件
// 向管道中添加中间件类的基本方法是调用 UseMiddleware<T>
app.UseMiddleware<LayoutMiddleware>();

// 我们还可以使用自定义扩展方法向管道中添加中间件。
app.UseLoggingMiddleware();


// 下面的中间件被注释掉了，因为它是一个终端中间件
//app.UseSimpleResponseMiddleware();

// 时间记录中间件
app.UseTimeLoggingMiddleware();

// 延迟中间件。
// 此时，延迟被包含在时间日志中。
app.UseIntentionalDelayMiddleware();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
