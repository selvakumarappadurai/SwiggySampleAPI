using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Swiggy.Dtos.Restaurant
{
    public class RestaurantForReadDto
    {
        public string Name { get; set; }

        public ReadOnlyCollection<FoodItemForCreateDto> Menu { get; set; }
    }
}
