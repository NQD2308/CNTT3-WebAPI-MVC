using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seminar.Models;

namespace Seminar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly Cntt3SerminarContext _ctx;
        public StoreController(Cntt3SerminarContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _ctx.Products.ToList();
                if(products.Count == 0)
                {
                    return NotFound("Product not available");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _ctx.Products.Find(id);
                if(product == null)
                {
                    return NotFound($"Product details not found with {id}");
                }
                return Ok(product);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                _ctx.Products.Add(product);
                _ctx.SaveChanges();

                return Ok("Product created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            ;
        }

        [HttpPut]
        public IActionResult Put(Product model)
        {
            if (model == null || model.Id == 0)
            {
                if(model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                else if(model.Id == 0)
                {
                    return BadRequest($"Product Id {model.Id} is invalid");
                }
            }

            try
            {
                var product = _ctx.Products.Find(model.Id);
                if(product == null)
                {
                    return NotFound($"Product not found with id {model.Id}");
                }
                product.Product1 = model.Product1;
                product.Img = model.Img;
                product.Price = model.Price;
                _ctx.SaveChanges();
                return Ok("Product details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _ctx.Products.Find(id);
                if( product == null)
                {
                    return NotFound($"Product not found {id}");
                }
                _ctx.Products.Remove(product);
                _ctx.SaveChanges();
                return Ok("Product details deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
