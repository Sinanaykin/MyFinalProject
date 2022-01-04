using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]//controller değişken burda controller ismine göre değişir
    [ApiController]//attribute.Classın controller oldugunu belirtiyoruz
    public class ProductsController : ControllerBase //ControllerBase den türeticez (View desteği olmadan oluşturulan bir sınıf=ControllerBase)
    {
       private IProductService _productService;//iletişim interface ler üzerinden olmalı.Buraya private vermesekde defaultu private zaten
        public ProductsController(IProductService productService)//dependency injention yaptık
        {
            _productService = productService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()//IActionResult Http kodlarını döndürebileceğimiz yapı dır 
        {
            Thread.Sleep(1000);

          var result = _productService.GetAll();
            if (result.Success)//eğer resul basarılı ise
            {
                return Ok(result);//GetAll dan sadece Datyı getirir istersek message,success getirebiliriz sadece result diyerek
            }
            return BadRequest(result);//eğer result basarılı değilse result ın messagı dönsün sadece
        }

        //[HttpGet("{id}")]//burada bir id alıcam diyebiliriz getleri ayırmak için
        [HttpGet("getbyid")]//yada 2. yol isim(alias) verebiliriz Get ler karısmasın diye hepsine isim vererek yapmak daha güzel
        public IActionResult GetById(int id)//GetById metodu bizden bir productId bekliyor burda ona id yi gönderiyoruz.
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("{id}")]//burada bir id alıcam diyebiliriz getleri ayırmak için
        [HttpGet("getbycategory")]//yada 2. yol isim(alias) verebiliriz Get ler karısmasın diye hepsine isim vererek yapmak daha güzel
        public IActionResult GetByCategory(int categoryid)//GetById metodu bizden bir productId bekliyor burda ona id yi gönderiyoruz.
        {
            var result = _productService.GetAllByCategory(categoryid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)//Yeni ürün ekleme metodu 
        {
            var result = _productService.Add(product);//_productService deki  add metoduna product gönder
            if (result.Success)//Eğer gönderilirse 
            {
                return Ok(result);//result döner yani resultın içinde success,message var .Burda data yok çünkü bu IResult
            }
            return BadRequest(result);//eğer result basarılı değilse result ın messagı dönsün sadece
        }

    }
    
}
