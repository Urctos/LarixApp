using WebAPI.Wrappers;

namespace WebAPI.MIddelwares
{
    public class ErrorHandlingMiddelware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response(false, ex.Message));
            }
        }
    }
}
