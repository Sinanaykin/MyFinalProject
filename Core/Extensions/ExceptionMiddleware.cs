using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
  
        public class ExceptionMiddleware
        {
            private RequestDelegate _next;

            public ExceptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext httpContext)//Invoke sürekli çalışan metod tur.
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception e)
                {
                    await HandleExceptionAsync(httpContext, e);//eğer hata alırsak aşağısı çalışssın
                }
            }

            private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
            {
                httpContext.Response.ContentType = "application/json"; //
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;//Olurda bir hata olursa InternalServerError verdik hatayı 500 yani

            string message = "Internal Server Error"; //mesaj olarak da bunu verdik
            IEnumerable<ValidationFailure> errors;//bir tane hata listesi oluşturduk  Hata listesinde dönen şey ValidationFailure(hatanın içindeki mesajdan gördük view details ekranından) dedik

            if (e.GetType() == typeof(ValidationException))//eğer aldığım hata validation exceptions ise
                {
                    message = e.Message;//message ı exception daki yani e'deki Message ile değiştir
                    errors = ((ValidationException) e).Errors;//gelen hata validationexception hatası oldugunu biliyoruz
                    httpContext.Response.StatusCode = 400; //Validation hatası ise  400 dönsün StatusCode.
                return httpContext.Response.WriteAsync(text: new ValidationErrorDetails //Eğer validation hatsı ise aşağıdakileri döner.Ağaşıdakiler de ErrorDetails daki prop lar
                {
                    StatusCode = 400,
                    Message = message,
                    Errors = errors
                }.ToString()); ;

                }

                return httpContext.Response.WriteAsync(new ErrorDetails//Eğer sistemsel bir hata ise bunları döner.Response uda bu format da yazdır diyoruz. StatusCode ve Message
                {
                    StatusCode = httpContext.Response.StatusCode,  //Bunu yukarıdan alıcak
                    Message = message
                }.ToString());
            }
        }
    }

