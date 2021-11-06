using System;

namespace Swiggy.Entity
{
    public class Order
    {
        public Guid Id { get; private set; }
        public FoodItem Item { get; private set; }
        public int Quantity { get; private set; }
        public Restaurant Restaurant { get; private set; }
    }
}
