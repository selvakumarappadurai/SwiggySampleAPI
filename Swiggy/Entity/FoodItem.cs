using System;

namespace Swiggy.Entity
{
    public class FoodItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal UnitPrice { get; private set; }

        public FoodItem(string name, decimal unitPrice)
        {
            Name = name;
            UnitPrice = unitPrice;
        }
    }
}
