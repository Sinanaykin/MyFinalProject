using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private ICategoryService _categoryService;//iletişim interface ler üzerinden olmalı.Buraya private vermesekde defaultu private zaten
        public CategoriesController(ICategoryService categoryService)//dependency injention yaptık
        {
            _categoryService = categoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()//IActionResult Http kodlarını döndürebileceğimiz yapı dır 
        {
           

            var result = _categoryService.GetAll();
            if (result.Success)//eğer resul basarılı ise
            {
                return Ok(result);//GetAll dan sadece Datyı getirir istersek message,success getirebiliriz sadece result diyerek
            }
            return BadRequest(result);//eğer result basarılı değilse result ın messagı dönsün sadece
        }


    }
}
