﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using DataAccess.Services;

namespace WebApp.Controllers
{
    [RoutePrefix("api/supplies")]
    public class SuppliesController : BaseController
    {
        [HttpGet]
        public List<Supply> Get()
        {
            var obj1 = new Supply()
            {
                Id = 1,
                ProductId = 1,
                ProvisionerId = 1,
                TimeStamp = new DateTime(2017,05,10)
            };

            var obj2 = new Supply()
            {
                Id = 1,
                ProductId = 1,
                ProvisionerId = 2,
                TimeStamp = new DateTime(2017, 05, 12)
            };

            return new List<Supply>() { obj1, obj2 };
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(Supply provisioner)
        {
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, Supply provisioner)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(Supply provisioner)
        {
        }

        public SuppliesController(DataService dataService) : base(dataService)
        {
        }
    }
}