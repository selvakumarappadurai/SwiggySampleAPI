using Microsoft.AspNetCore.Mvc;
using Swiggy.Dtos.Order;
using Swiggy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiggy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly SwiggyDbContext _swiggyDbContext;

        public OrderController(SwiggyDbContext swiggyDbContext)
        {
            _swiggyDbContext = swiggyDbContext;
        }

        [HttpPost(nameof(CreateOrder))]
        public IActionResult CreateOrder(OrderForCreateDto orderForCreateDto)
        {
            _swiggyDbContext.Orders.Add(new Order(orderForCreateDto.ItemId, orderForCreateDto.RestaurantId,
                orderForCreateDto.Quantity, orderForCreateDto.CustomerId));
            _swiggyDbContext.SaveChanges();
            return Ok();
        }
    }
}
