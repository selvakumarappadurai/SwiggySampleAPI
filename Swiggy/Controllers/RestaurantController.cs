using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swiggy.Dtos.Restaurant;
using Swiggy.Entity;
using System.Linq;

namespace Swiggy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly SwiggyDbContext _swiggyDbContext;

        public RestaurantController(SwiggyDbContext swiggyDbContext)
        {
            _swiggyDbContext = swiggyDbContext;
        }

        [HttpGet(Name = nameof(GetRestaurants))]
        public IActionResult GetRestaurants()
        {
            var test = _swiggyDbContext.Restaurants.Include(r => r.FoodItems).ToList();
            return Ok(test);
        }

        [HttpGet("{name}", Name = nameof(GetRestaurantByName))]
        public IActionResult GetRestaurantByName(string name)
        {
            return Ok(_swiggyDbContext.Restaurants.Include(r => r.FoodItems).SingleOrDefault(rsrt => rsrt.Name == name));
        }

        [HttpPost(nameof(CreateRestaurant))]
        public IActionResult CreateRestaurant(RestaurantForCreateDto restaurantForCreateDto)
        {
            //_swiggyDbContext.Restaurants.Add(new Restaurant(restaurantForCreateDto.Name,
            //    restaurantForCreateDto.Menu.Select(m => new FoodItem(m.Name, m.UnitPrice)).ToList()));
            var newRestaurant = new Restaurant(restaurantForCreateDto.Name);
            newRestaurant.AddFoodItems(restaurantForCreateDto.Menu.Select(m => new FoodItem(m.Name, m.UnitPrice)).ToList());
            _swiggyDbContext.Restaurants.Add(newRestaurant);
            _swiggyDbContext.SaveChanges();
            return Ok();
        }
    }
}
