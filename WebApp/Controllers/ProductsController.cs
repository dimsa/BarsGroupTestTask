using DataAccess.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DataAccess;
using DataAccess.Services;

namespace WebApp.Controllers
{
    [RoutePrefix("api/products")]
    [EnableCors(origins: "http://localhost:11215", headers: "*", methods: "*")]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public List<Product> Get()
        {
            var obj1 = new Product()
            {
                Id = 1,
                Code = Guid.NewGuid(),
                Name = "tet"
            };

            var obj2 = new Product()
            {
                Id = 2,
                Code = Guid.NewGuid(),
                Name = "test2"
            };

            var product = DataService.AddProduct();


            return new List<Product>() { obj1, obj2, product };
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(Product product)
        {
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, Product product)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(Product product)
        {
        }

        public ProductsController(DataService dataService) : base(dataService)
        {
            
        }
    }
}
