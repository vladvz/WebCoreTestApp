using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCoreTestApp.Data;

namespace WebCoreTestApp.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IWebCoreRepository _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IWebCoreRepository repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex.Message}");

                return BadRequest("Failed to get orders");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);

                if (order != null)
                    return Ok(_repository.GetOrderById(id));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get order: {ex.Message}");

                return BadRequest("Failed to get order");
            }
        }
    }
}
