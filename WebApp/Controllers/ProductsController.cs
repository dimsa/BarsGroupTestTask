using DataAccess.Entities;
using System.Collections.Generic;
using System.Web.Http;
using DataAccess.Services;

namespace WebApp.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public List<Product> Get(int start = 0, int limit = 25)
        {
            return DataService.GetProducts(start, limit);            
        }

        [HttpPut]
        public void Put(Product product)
        {
            DataService.UpdateProduct(product);
        }

        [HttpPost]
        public Product Post(Product product)
        {
            return DataService.AddProduct();
        }

        [HttpDelete]
        public void Delete(int id, Product product)
        {
            DataService.DeleteProduct(product);
        }

        public ProductsController(DataService dataService) : base(dataService)
        {
            
        }
    }
}
