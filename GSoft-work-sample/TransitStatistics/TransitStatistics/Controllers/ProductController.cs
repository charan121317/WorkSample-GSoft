using DeliveryLogistics.Dto;
using DeliveryLogistics.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryLogistics.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("{name}/transit")]
        public IdealProductTransit Get([FromRoute] string name)
        {
            return _productService.GetProductTransitDetails(name);
        }

        [HttpGet]
        [Route("names")]
        public IEnumerable<string> GetNames()
        {
            return _productService.GetProductNames();
        }
    }
}