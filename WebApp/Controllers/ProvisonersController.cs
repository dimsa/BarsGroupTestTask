using DataAccess.Entities;
using System.Collections.Generic;
using System.Web.Http;
using DataAccess.Services;

namespace WebApp.Controllers
{
    [RoutePrefix("api/provisioners")]
    public class ProvisionersController : BaseController
    {
        [HttpGet]
        public List<Provisioner> Get(int start = 0, int limit = 25)
        {
           return DataService.GetProvisioner(start, limit);
        }    

        [HttpPut]
        public void Put(int id, Provisioner provisioner)
        {
            DataService.UpdateProvisioner(provisioner);
        }

        [HttpPost]
        public Provisioner Post(Provisioner provisioner)
        {
            return DataService.AddProvisioner();
        }

        [HttpDelete]
        public void Delete(Provisioner provisioner)
        {
            DataService.DeleteProvisioner(provisioner);
        }

        public ProvisionersController(DataService dataService) : base(dataService)
        {
        }
    }
}
