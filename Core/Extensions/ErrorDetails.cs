using Core.Extensions;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public class ErrorDetails//Sistemsel hatası ise bunları alır
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); //Serialize işlemini burda yapıyoruz ErrorDetails ın yani StatusCode ve Message  ın.
        }
    }
}

public class ValidationErrorDetails:ErrorDetails //Validation hatası ise hem yukardakini hem aşağıdaki ni alır
{
    public IEnumerable<ValidationFailure> Errors { get; set; }
}
