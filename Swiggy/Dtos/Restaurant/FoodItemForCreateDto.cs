using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiggy.Dtos.Restaurant
{
    public class FoodItemForCreateDto
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
