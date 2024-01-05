using System.IO;

public class CheckSessionMiddleware
{
    private readonly RequestDelegate _next;

    public CheckSessionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        // Check if the session is set
        if (context.Session.GetString("UserId") == null)
        {
            var path = context.Request.Path.Value;
            if (!path.StartsWith("/Home") && !path.StartsWith("/Authentication"))
            {
                context.Response.Redirect("/Authentication/Index");
            }
            else
            {
                await _next(context);
            }

            // If the session is not set, check if the current path is login or register
            //context.Response.Redirect("/Authentication/Index");

        }
        else
        {
            // If the session is set, continue with the next middleware in the pipeline
            await _next(context);
        }
    }
}
