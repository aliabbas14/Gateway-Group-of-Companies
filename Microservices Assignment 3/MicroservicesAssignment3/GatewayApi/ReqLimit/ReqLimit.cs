using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace GatewayApi
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ReqLimitAttribute : ActionFilterAttribute
    {
        public ReqLimitAttribute(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public int NoOfRequest { get; set; } = 5;
        public int Seconds { get; set; } = 20;
        private static MemoryCache Cache { get; } = new MemoryCache(new MemoryCacheOptions());
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var ipAddress = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            var memoryCacheKey = $"{Name}-{ipAddress}";
            Cache.TryGetValue(memoryCacheKey, out int prevReqCount);
            if (prevReqCount >= NoOfRequest)
            {
                context.Result = new ContentResult
                {
                    Content = $"Request limit is exceeded. Try again in {Seconds} seconds.",
                };
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
            }
            else
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(Seconds));
                Cache.Set(memoryCacheKey, (prevReqCount + 1), cacheEntryOptions);
            }
        }
    }
}