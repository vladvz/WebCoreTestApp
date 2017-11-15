using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebCoreTestApp.Data;
using WebCoreTestApp.Data.Entities;
using WebCoreTestApp.ViewModels;

namespace WebCoreTestApp.Controllers
{
    [Route("/api/orders/{orderid}/items")]
    public class OrderItemsController : Controller
    {
        private readonly IWebCoreRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IWebCoreRepository repository, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderid)
        {
            var order = _repository.GetOrderById(orderid);

            if (order != null)
            {
                return Ok(_mapper.Map<IEnumerable<OrderItem>,IEnumerable<OrderItemViewModel>>(order.Items));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderid, int id)
        {
            var order = _repository.GetOrderById(orderid);

            if (order != null)
            {
                var orderItem = order.Items.Where(item => item.Id.Equals(id)).FirstOrDefault();

                if (orderItem != null)
                    return Ok(_mapper.Map<OrderItem, OrderItemViewModel>(orderItem));
                else
                    return NotFound();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
