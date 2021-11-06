using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiggy.Dtos.Restaurant
{
    public class RestaurantForCreateDto
    {
        public string Name { get; set; }
        public List<FoodItemForCreateDto> Menu { get; set; }
    }
}
