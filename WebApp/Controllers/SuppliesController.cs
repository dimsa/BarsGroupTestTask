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
        public ListWithTotal<SupplyDto> Get(int start = 0, int limit = 25)
        {
            var res = DataService.GetSupplies(start, limit, out var totalCount);            
            var list = res.Select(DtoConverter.SupplyModelToDto).ToList();

            return new ListWithTotal<SupplyDto>(list, totalCount);
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
            var res = new DtoWithProperties<SupplyDto>(DataService.AddSupply(DtoConverter.SupplyDtoToModel(supply), out ex));

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
