using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Data;
using ProductCatalogAPI.DTOs;
using ProductCatalogAPI.Model;
using ProductCatalogAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    //Show all
    [HttpGet] 
    public async Task<IActionResult> GetAllAsync()
    {
        var products = await _service.GetAllAsync();
        _logger.LogInformation("Fetching all products");

        return Ok(products);
    }

    //Add new
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateProductDTO dto)
    {
        var product = await _service.CreateAsync(dto);
        _logger.LogInformation($"Created: {product.Id}");

        return CreatedAtAction(nameof(GetByIdAsync), new { id = product.Id }, product);
    }

    //Search By (ID)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var product = await _service.GetByIdAsync(id);

        if (product == null)
            return NotFound();
            

        _logger.LogInformation($"Fetched data: {product.Id}");
        return Ok(product);
    }

    //Update
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateProductDTO dto)
    {
        var product = await _service.UpdateAsync(id, dto);

        if (product == null)
            return NotFound();

        _logger.LogInformation($"Updated: {product.Id}");
        return Ok("ID: " + product + " is Updated Successfully! ");
    }

    //Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var success = await _service.DeleteAsync(id);

        if (!success)
            return NotFound();

        _logger.LogInformation($"Deleted: {id}");
        return NoContent();
    }

    //Search
    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync(string keyword)
    {
        var result = await _service.SearchAsync(keyword);

        if (result == null) return NotFound();

        _logger.LogInformation($"Fetched Data: {keyword}");
        return Ok(result);
    }
}
