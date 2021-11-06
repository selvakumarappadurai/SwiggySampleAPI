using System;
using System.Collections.Generic;

namespace Swiggy.Entity
{
    public class Customer
    {
        private readonly List<Order> _orders = new List<Order>();

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Email { get; private set; }
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    }
}
