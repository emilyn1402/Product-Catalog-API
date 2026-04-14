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

    public ProductController(IProductService service)
    {
        _service = service;
    }

    //Show all
    [HttpGet] 
    public async Task<IActionResult> GetAllAsync()
    {
        var products = await _service.GetAllAsync();

        return Ok(products);
    }

    //Add new
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateProductDTO dto)
    {
        var product = await _service.CreateAsync(dto);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = product.Id }, product);
    }

    //Search By (ID)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var product = await _service.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    //Update
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateProductDTO dto)
    {
        var product = await _service.UpdateAsync(id, dto);

        if (product == null)
            return NotFound();

        return Ok("ID: " + product + " is Updated Successfully! ");
    }

    //Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var success = await _service.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }

    //Search
    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync(string keyword)
    {
        var result = await _service.SearchAsync(keyword);

        if (result == null) return NotFound();

        return Ok(result);
    }
}
