﻿using Commons.Helpers;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await GenerateLogHelper.LogError(ex, "ExceptionMiddleware", ex.TargetSite.Name);
            }
        }
    }
}
