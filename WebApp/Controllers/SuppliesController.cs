using DataAccess.Entities;
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
        public List<Supply> Get(int start = 0, int limit = 25)
        {
            return DataService.GetSupplies(start, limit);
        }

        [HttpPut]
        public void Put(Supply supply)
        {
            DataService.UpdateSupply(supply);
        }

        [HttpPost]
        public Supply Post(Supply supply)
        {
            return DataService.AddSupply(supply);
        }

        [HttpDelete]
        public void Delete(int id, Supply supply)
        {
            DataService.DeleteSupply(supply);
        }

        public SuppliesController(DataService dataService) : base(dataService)
        {
        }
    }
}
