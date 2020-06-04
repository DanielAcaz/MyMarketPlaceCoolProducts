using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyMarketPlaceCoolProducts.Error;
using MyMarketPlaceCoolProducts.Model;
using MyMarketPlaceCoolProducts.Services;

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
        public ActionResult<IEnumerable<Product>> Get() =>
            Ok(Service.GetProducts());

        [HttpDelete("{_Id}")]
        public IActionResult DeleteById(long _Id)
        {
            Product ProductDeleted = Service.DeleteById(_Id);
            if (ProductDeleted is Product.EmptyProduct)
                return NotFound();
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product _Product)
        {
            try
            {
                Product Product = Service.CreateProduct(_Product);
                return base.CreatedAtRoute(nameof(GetById),
                    new { id = _Product.Id },
                    Product);
            }
            catch (InvalidProductException Error)
            {
                return BadRequest(Error.Message);
            }

            
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public ActionResult<Product> GetById(long Id)
        {
            Product Product = Service.GetById(Id);
            if (Product is Product.EmptyProduct)
                return NotFound();
            return Ok(Product);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(long Id, [FromBody]
            Product Product)
        {
            return CreatedAtRoute(
                nameof(GetById),
                new { id = Id },
                Service.UpdateProduct(Product, Id));
            
        }
    }
}
