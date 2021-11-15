using System;

namespace Swiggy.Dtos.Order
{
    public class OrderForCreateDto
    {
        public Guid ItemId { get; set; }
        public Guid RestaurantId { get; set; }
        public int Quantity { get; set; }
        public Guid CustomerId { get; set; }
    }
}
