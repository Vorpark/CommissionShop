using API.DAL.Data;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DbSet<Customer> _context;
        public CustomerController(ApplicationDbContext context) => _context = context.Customers;
    }
}
