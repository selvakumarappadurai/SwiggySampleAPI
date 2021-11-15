using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swiggy.Dtos.Customer;
using Swiggy.Entity;
using System.Linq;

namespace Swiggy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly SwiggyDbContext _swiggyDbContext;

        public CustomerController(SwiggyDbContext swiggyDbContext)
        {
            _swiggyDbContext = swiggyDbContext;
        }

        [HttpGet(Name = nameof(GetCustomers))]
        public IActionResult GetCustomers()
        {
            var test = _swiggyDbContext.Customers.ToList();
            return Ok(test);
        }

        [HttpGet("{email}", Name = nameof(GetCustomer))]
        public IActionResult GetCustomer(string email)
        {
            var test = _swiggyDbContext.Customers.SingleOrDefault(cust => cust.Email.Equals(email));
            return Ok(test);
        }

        [HttpPost(nameof(CreateCustomer))]
        public IActionResult CreateCustomer(CustomerForCreateDto customerForCreateDto)
        {
            _swiggyDbContext.Customers.Add(new Customer(customerForCreateDto.Name, customerForCreateDto.Email));
            try
            {
                _swiggyDbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException)
                {
                   
                }
            }
            return Ok();
        }
    }
}
