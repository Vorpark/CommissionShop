using API.DAL.Repositories.IRepository;
using API.Domain.DTOs.Product;
using API.Domain.QueryObjects;
using API.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController(IProductRepository repository) : ControllerBase
    {
        private readonly IProductRepository _repository = repository;

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var productDTO = product.ToProductResponseDTO();

            return Ok(productDTO);
        }

        [HttpGet]
        [Authorize(Policy = "ReadAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();

            var productDTOs = products.Select(x => x.ToProductResponseDTO());

            return Ok(productDTOs);
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetPageByQuery([FromQuery] ProductQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var products = await _repository.GetPageByQueryAsync(query);

            var productDTOs = products.Select(x => x.ToProductPageResponseDTO());

            return Ok(productDTOs);
        }

        [HttpPost]
        [Authorize(Policy = "Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = productDTO.ToProductFromCreateRequestDTO();
            await _repository.CreateAsync(product);

            var createdProductDTO = product.ToProductResponseDTO();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, createdProductDTO);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = "Update")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequestDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _repository.UpdateAsync(id, productDTO);

            if (product == null)
                return NotFound();

            var updatedProductDTO = product.ToProductResponseDTO();

            return Ok(updatedProductDTO);
        }

        [HttpPut("{id:guid}-{isSold:bool}")]
        [Authorize(Policy = "Update")]
        public async Task<IActionResult> UpdateIsSold([FromRoute] Guid id, [FromRoute] bool isSold)
        {
            var product = await _repository.UpdateIsSoldAsync(id, isSold);

            if (product == null)
                return NotFound();

            var updatedProductDTO = product.ToProductResponseDTO();

            return Ok(updatedProductDTO);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "Delete")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var product = await _repository.DeleteAsync(id);

            if (product == null)
                return BadRequest(id);

            return NoContent();
        }
    }
}
