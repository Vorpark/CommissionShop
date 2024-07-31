using API.DAL.Repositories.IRepository;
using API.Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController(IProductRepository repository) : ControllerBase
    {
        private readonly IProductRepository _repository = repository;

        [HttpGet("{id:guid}")]
        public ActionResult<ProductDTO> GetById([FromRoute] Guid id)
        {
            var product = _repository.GetById(id).Result;

            if(product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAll()
        {
            var products = _repository.GetAll().Result;

            if(products == null)
                return NotFound();

            return Ok(products);
        }
    }
}
