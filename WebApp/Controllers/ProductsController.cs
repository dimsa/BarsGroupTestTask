using DataAccess.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApp.Controllers
{
    [RoutePrefix("api/products")]
    [EnableCors(origins: "http://localhost:11215", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        // GET api/values
        [HttpGet]
        public List<Product> Get()
        {
         //   return new string[] { "value1", "value2" };

            var obj = new Product()
            {
                Code = new Guid(),
                Name = "tet"
            };
            return new List<Product>() { obj };//{[" + JsonConvert.SerializeObject(obj) + "]}";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
