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
        public Supply Post(SupplyDto supply)
        {
            return DataService.AddSupply(DtoConverter.SupplyDtoToModel(supply));
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
