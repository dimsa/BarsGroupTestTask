using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using DataAccess.Services;
using WebApp.Common;

namespace WebApp.Controllers
{
    [RoutePrefix("api/export")]
    public class ExportController : BaseController
    {
        private string ComposeHtmlData()
        {
            DataService.GetSupplies(0, 1, out var totalCount);
            var res = DataService.GetSupplies(0, totalCount, out var _);
            return Exporter.ExportToHtml(res);
        }

        private HttpResponseMessage composeFormattedData(string data, string extenstion, string mediaHeaderTpe)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            var content = new StringContent(data);
            response.Content = content;

            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "export." + extenstion;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaHeaderTpe);

            return response;
        }

        [HttpGet]
        [Route("xls")]
        public HttpResponseMessage GetXls()
        {
            var html = ComposeHtmlData();
            return composeFormattedData(html, "xls", "application/ms-excel");
        }

        [HttpGet]
        [Route("doc")]
        public HttpResponseMessage GetDoc()
        {
            var html = ComposeHtmlData();
            return composeFormattedData(html, "doc", "application/ms-word");           
        }

        public ExportController(DataService dataService) : base(dataService)
        {
            
        }
    }
}
