using Microsoft.AspNetCore.Mvc;
using OrderSolution.Models;
using OrderSolution.Services;

namespace OrderSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;


        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderService.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var order = _orderService.GetById(id);
            return order == null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            var createdOrder = _orderService.Create(order);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }


        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(Guid id, [FromBody] string status)
        {
            var updated = _orderService.UpdateStatus(id, status);
            return updated ? NoContent() : NotFound();
        }
    }
}
