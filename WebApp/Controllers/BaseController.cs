using System.Web.Http;
using DataAccess;
using DataAccess.Services;

namespace WebApp.Controllers
{
    public class BaseController : ApiController
    {
        protected DataService DataService { get; set; }

        /* protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (!filterContext.IsChildAction)
            UnitOfWork.BeginTransaction();
    }

    protected override void OnResultExecuted(ResultExecutedContext filterContext)
    {
        if (!filterContext.IsChildAction)
            UnitOfWork.Commit();
    }*/

        public BaseController(DataService dataService)
        {
            DataService = dataService;
        }
    }
}