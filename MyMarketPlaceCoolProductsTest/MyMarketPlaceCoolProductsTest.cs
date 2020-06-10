using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyMarketPlaceCoolProducts.Controllers;
using MyMarketPlaceCoolProducts.DTO;
using MyMarketPlaceCoolProducts.Services;
using NSubstitute;
using Xunit;

namespace MyMarketPlaceCoolProductsTest
{
    public class ProductControllerTest
    {

        private IService serviceMock;

        [Fact]
        public void Should_Return_Stauts_200_To_GET()
        {
            serviceMock = Substitute.For<IService>();
            serviceMock.GetProducts()
                       .Returns(new List<ProductDTO>());

            var controller = new ProductController(serviceMock);

            ActionResult<IEnumerable<ProductDTO>> actionResult = controller.Get();

            Assert.IsType<OkObjectResult>(actionResult.Result);





        }
    }
}
