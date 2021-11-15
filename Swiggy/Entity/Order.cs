using System;

namespace Swiggy.Entity
{
    public class Order
    {
        public Guid Id { get; private set; }
        public FoodItem Item { get; private set; }
        public int Quantity { get; private set; }
        public Restaurant Restaurant { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid FoodItemId { get; private set; }
        public Guid RestaurantId { get; private set; }
        public Customer Customer { get; private set; }
        public DateTimeOffset OrderedDate { get; private set; }

        private Order() { }
        public Order(Guid foodItemId, Guid restaurantId, int quantity, Guid customerId)
        {
            FoodItemId = foodItemId;
            RestaurantId = restaurantId;
            Quantity = quantity;
            CustomerId = customerId;
            OrderedDate = DateTime.Now;
        }
    }
}
