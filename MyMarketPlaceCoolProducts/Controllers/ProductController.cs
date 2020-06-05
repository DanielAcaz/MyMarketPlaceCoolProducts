using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyMarketPlaceCoolProducts.DTO;
using MyMarketPlaceCoolProducts.Error;
using MyMarketPlaceCoolProducts.Models;
using MyMarketPlaceCoolProducts.Services;
using static MyMarketPlaceCoolProducts.Creationals.ProductFactory;

namespace MyMarketPlaceCoolProducts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        readonly IService Service;

        public ProductController(IService _Service)
        {
            Service = _Service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get() =>
            Ok(Service.GetProducts());

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string Id)
        {
            try
            {
                ProductDTO ProductDeleted = Service.DeleteById(Id);
                if (ProductDeleted is EmptyProduct)
                    return NotFound();
                return NoContent();
            }
            catch (InvalidProductException Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] ProductDTO _Product)
        {
            try
            {
                ProductDTO Product = Service.CreateProduct(_Product);
                _Product.Id = Product.Id;
                return CreatedAtRoute(
                    nameof(GetById),
                    new { id = _Product.Id },
                    Product);
            }
            catch (InvalidProductException Error)
            {
                return BadRequest(Error.Message);
            }

            
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public ActionResult<ProductDTO> GetById(string id)
        {
            ProductDTO Product = Service.GetById(id);
            if (Product is EmptyProduct)
                return NotFound();
            return Ok(Product);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDTO> UpdateProduct(string Id, [FromBody]
            ProductDTO Product)
        {
            try
            {
                return CreatedAtRoute(
                    nameof(GetById),
                    new { id = Id },
                    Service.UpdateProduct(Product, Id));
            }
            catch (InvalidProductException Error)
            {
                return BadRequest(Error.Message);
            }
        }
    }
}
