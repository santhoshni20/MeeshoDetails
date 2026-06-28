using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CampaignManagement.Helpers.Middlewares
{
    public class ActivityLoggingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
        }
    }
}
