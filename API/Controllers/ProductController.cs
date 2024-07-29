using API.DAL.Data;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbSet<Product> _context;
        public ProductController(ApplicationDbContext context) => _context = context.Products;
    }
}
