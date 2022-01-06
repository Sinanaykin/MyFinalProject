using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)//IApplicationBuilder bu yapı startup da var zaten hazır
        {
            app.UseMiddleware<ExceptionMiddleware>();//Startup da çalışan Middleware ler dışında bunuda(ExceptionMiddleware) ekle orda çalıştır diyoruz
        }
    } 
}
