using Microsoft.AspNetCore.Builder;


namespace gsg.Middlewares
{
    public static class DataseederMiddlewareExtensions
    {
        public static IApplicationBuilder UseDataseeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DataseederMiddleware>();
        }
    }
}
