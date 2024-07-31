using API.DAL.Repositories.IRepository;
using API.Domain.Models.DTOs.Product;
using API.Mappers;
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
            //Map
            if (product == null)
                return NotFound();

            return Ok(product.ToProductDTO());
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAll()
        {
            var products = _repository.GetAll().Result;
            //Map
            if (products == null)
                return NotFound();

            return Ok(products.Select(x => x.ToProductDTO()));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductRequestDTO productDTO) 
        {
            var product = productDTO.ToProductFromCreaterDTO();
            _repository.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id}, product.ToProductDTO());
        }
    }
}
