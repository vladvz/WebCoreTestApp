using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebCoreTestApp.Data;

namespace WebCoreTestApp.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IWebCoreRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IWebCoreRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex.Message}");

                return BadRequest("Failed to get products");
            }
        }
    }
}
