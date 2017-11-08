using System;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccess.Services;
using WebApp.Common;

namespace WebApp.Controllers
{
    [RoutePrefix("api/supplies")]
    public class SuppliesController : BaseController
    {
        [HttpGet]
        public List<SupplyDto> Get(int start = 0, int limit = 25)
        {
            var res = DataService.GetSupplies(start, limit);            
            return res.Select(DtoConverter.SupplyModelToDto).ToList();
        }
     
        [HttpPut]
        public void Put(SupplyDto supply)
        {
            DataService.UpdateSupply(DtoConverter.SupplyDtoToModel(supply));
        }

        [HttpPost]
        public IHttpActionResult Post(SupplyDto supply)
        {
            Exception ex;
            var res = DataService.AddSupply(DtoConverter.SupplyDtoToModel(supply), out ex);

            if (ex == null)
            {
                return Ok(res);
            }
            else
            {
                return Conflict();
            }
        }

        [HttpDelete]
        public void Delete(int id, SupplyDto supply)
        {
            DataService.DeleteSupply(id);
        }

        public SuppliesController(DataService dataService) : base(dataService)
        {
        }
    }
}
