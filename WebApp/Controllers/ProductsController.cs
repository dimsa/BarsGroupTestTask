using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccess.Services;
using WebApp.Common;

namespace WebApp.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public ListWithTotal<ProductDto> Get(int start = 0, int limit = 25)
        {
            var res = DataService.GetProducts(start, limit, out var totalCount);            
            var list = res.Select(DtoConverter.ProductModelToDto).ToList();

            return new ListWithTotal<ProductDto>(list, totalCount);

        }

        [HttpPut]
        public void Put(ProductDto product)
        {
            DataService.UpdateProduct(DtoConverter.ProductDtoToModel(product));
        }

        [HttpPost]
        public ProductDto Post(ProductDto product)
        {
            return DtoConverter.ProductModelToDto(DataService.AddProduct());
        }

        [HttpDelete]
        public void Delete(int id, ProductDto product)
        {
            DataService.DeleteProduct(id);
        }

        public ProductsController(DataService dataService) : base(dataService)
        {
            
        }
    }
}
