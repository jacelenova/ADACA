using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace ADACA.Attributes
{
    public class CacheResultAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
            var bodyString = await GetRawBodyAsync(context.HttpContext.Request);
            var hash = bodyString.GetHashCode();
            if (cache != null)
            {
                if (cache.TryGetValue(hash, out var value))
                {
                    context.Result = new ObjectResult(value);
                    return;
                }
            }

            var executedContext = await next();

            var result = executedContext.Result;
            if (cache != null && result != null)
            {
                if (result is ObjectResult)
                {
                    var value = ((ObjectResult)result).Value;
                    cache.Set(hash, value);
                }
            }
        }

        private async Task<string> GetRawBodyAsync(HttpRequest request)
        {
            request.Body.Position = 0;
            var reader = new StreamReader(request.Body, Encoding.UTF8);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;

            return body;
        }
    }
}
