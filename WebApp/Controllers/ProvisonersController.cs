using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccess.Services;
using WebApp.Common;

namespace WebApp.Controllers
{
    [RoutePrefix("api/provisioners")]
    public class ProvisionersController : BaseController
    {
        [HttpGet]
        public List<ProvisionerDto> Get(int start = 0, int limit = 25)
        {
            var res = DataService.GetProvisioner(start, limit);
            return res.Select(DtoConverter.ProvisionerModelToDto).ToList();
        }    

        [HttpPut]
        public void Put(int id, ProvisionerDto provisioner)
        {
            DataService.UpdateProvisioner(DtoConverter.ProvisionerDtoToModel(provisioner));
        }

        [HttpPost]
        public ProvisionerDto Post(ProvisionerDto provisioner)
        {
            return DtoConverter.ProvisionerModelToDto(DataService.AddProvisioner());
        }

        [HttpDelete]
        public void Delete(int id, ProvisionerDto provisioner)
        {
            DataService.DeleteProvisioner(id);
        }

        public ProvisionersController(DataService dataService) : base(dataService)
        {
        }
    }
}
