using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApp;
using WebApp.Controllers;
using Xunit;

namespace WebApp.Tests.Controllers
{
    public class ValuesControllerTest
    {
        [Fact]
        public void Get()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("value1", result.ElementAt(0));
            Assert.Equal("value2", result.ElementAt(1));
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.Equal("value", result);
        }

        [Fact]
        public void Post()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            controller.Post("value");

            // Assert
        }

        [Fact]
        public void Put()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [Fact]        
        public void Delete()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
