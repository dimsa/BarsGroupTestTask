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
    [RoutePrefix("api/provisioners")]
    [EnableCors(origins: "http://localhost:11215", headers: "*", methods: "*")]
    public class ProvisionersController : ApiController
    {
        [HttpGet]
        public List<Provisioner> Get()
        {
            var obj1 = new Provisioner()
            {
                Id = 1,
                Name = "provisioner 1"
            };

            var obj2 = new Provisioner()
            {
                Id = 2,
                Name = "provisioner 2"
            };

            return new List<Provisioner>() { obj1, obj2 };
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(Provisioner provisioner)
        {
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, Provisioner provisioner)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(Provisioner provisioner)
        {
        }
    }
}
