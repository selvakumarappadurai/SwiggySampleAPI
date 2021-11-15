using System;
using System.Collections.Generic;

namespace Swiggy.Entity
{
    public class Restaurant
    {
        // this is needed when using concreate class instead of interface for navigation properties
        // ReadOnlyCollection instead of IReadOnlyCollection
        //private Restaurant() { _foodItems = new List<FoodItem>(); }
        private Restaurant() { }
        private readonly List<FoodItem> _foodItems = new List<FoodItem>();

        public Restaurant(string name)
        {
            //Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IReadOnlyCollection<FoodItem> FoodItems => _foodItems.AsReadOnly();

        public void AddFoodItems(List<FoodItem> foodItems)
        {
            _foodItems.AddRange(foodItems);
        }
    }
}
