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
        public ListWithTotal<ProvisionerDto> Get(int start = 0, int limit = 25)
        {
            var res = DataService.GetProvisioner(start, limit, out var totalCount);
            var list = res.Select(DtoConverter.ProvisionerModelToDto).ToList();             

            return new ListWithTotal<ProvisionerDto>(list, totalCount);
        }    

        [HttpPut]
        public void Put(int id, ProvisionerDto provisioner)
        {
            DataService.UpdateProvisioner(DtoConverter.ProvisionerDtoToModel(provisioner));
        }

        [HttpPost]
        public DtoWithProperties<ProvisionerDto> Post(ProvisionerDto provisioner)
        {
            return new DtoWithProperties<ProvisionerDto>(DtoConverter.ProvisionerModelToDto(DataService.AddProvisioner()));
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
