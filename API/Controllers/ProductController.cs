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

            var productDTO = product.ToProductDTO();

            return Ok(productDTO);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();

            if (products == null)
                return NotFound();

            var productDTOs = products.Select(x => x.ToProductDTO());

            return Ok(productDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDTO productDTO) 
        {
            if (!ModelState.IsValid)
                return BadRequest(productDTO);

            var product = productDTO.ToProductFromCreateDTO();
            await _repository.AddAsync(product);

            var createdProductDTO = product.ToProductDTO();

            return CreatedAtAction(nameof(GetById), new { id = product.Id}, createdProductDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequestDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(productDTO);

            var product = await _repository.UpdateAsync(id, productDTO);

            if (product == null)
                return NotFound();

            var updatedProductDTO = product.ToProductDTO();

            return Ok(updatedProductDTO);
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
