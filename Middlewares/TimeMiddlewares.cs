
public class TimeMiddlewares
{

    readonly RequestDelegate next;


    public TimeMiddlewares(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }


    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {

        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            context.Response.ContentType = "application/json";
            var resObj = new { time = DateTime.Now.ToShortTimeString() };
            string jsonResponse = System.Text.Json.JsonSerializer.Serialize(resObj);
            await context.Response.WriteAsync(jsonResponse);

        }

        await next(context);

    }
}


public static class TimeMiddlewaresExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddlewares>();
    }
}