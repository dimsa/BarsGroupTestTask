using System.Web.Http;
using System.Web.Http.Cors;
using DataAccess;
using DataAccess.Services;

namespace WebApp.Controllers
{
    [EnableCors(origins: "http://localhost:11215", headers: "*", methods: "*")]
    public abstract class BaseController : ApiController
    {
        protected DataService DataService { get; set; }

        protected BaseController(DataService dataService)
        {
            DataService = dataService;
        }
    }
}