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
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product.ToProductDTO());
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();

            if (products == null)
                return NotFound();

            return Ok(products.Select(x => x.ToProductDTO()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDTO productDTO) 
        {
            if (productDTO == null)
                return BadRequest(productDTO);

            var product = productDTO.ToProductFromCreateDTO();
            await _repository.AddAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id}, product.ToProductDTO());
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequestDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest(productDTO);

            var product = await _repository.UpdateAsync(id, productDTO);

            if (product == null)
                return NotFound();

            return Ok(product.ToProductDTO());
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var product = await _repository.DeleteAsync(id);

            if (product == null)
                return BadRequest(id);

            return NoContent();
        }
    }
}
