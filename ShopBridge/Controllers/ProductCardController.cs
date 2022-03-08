using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBridge.Controllers.Entity;
using ShopBridge.Repo;
using ShopBridge.Repo.Entity;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductCardController : ControllerBase
    {
       
        
        private readonly IProductRepo _productRepo;
        public ProductCardController( IProductRepo productRepo)
        {
            _productRepo = productRepo;

        }
        [HttpGet]
        [Route("GET")]
        public async Task<IActionResult> GetProduct()
        {
            //string filter = JsonConvert.SerializeObject(request);
            //ProductDetails Pdata = JsonConvert.DeserializeObject<ProductDetails>(filter);
            var result = _productRepo.GetProducts();
            if (result == null)
            {
                return NotFound();
            }
            else
                return Ok(result);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProduct(ProductData request)
        {
            if (request != null)
            {
                string filter = JsonConvert.SerializeObject(request);
                ProductDetails Pdata = JsonConvert.DeserializeObject<ProductDetails>(filter);
                var result = _productRepo.AddProduct(Pdata);
                if (result == null)
                {
                    return NotFound();
                }
                else
                    return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateProduct(ProductData request)
        {
            if (request != null)
            {
                string filter = JsonConvert.SerializeObject(request);
                ProductDetails Pdata = JsonConvert.DeserializeObject<ProductDetails>(filter);
                var result = _productRepo.UpdateProduct(Pdata);

                if (result == null)
                {
                    return NotFound();
                }
                else
                    return Ok( "Data Updated successfully for Id:"+result.Product_Id);
            }
            else return BadRequest();
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteProduct(string ProductId)
        {
            var result = _productRepo.DeleteProduct(ProductId);
            if (result == null)
            {
                return NotFound();
            }
            else
                return Ok(result);
        }
    }
}
