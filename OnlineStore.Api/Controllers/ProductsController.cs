using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Api.Models;
using OnlineStore.Shared;

namespace OnlineStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        return await _context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                ImageUrl = p.ImageUrl
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var p = await _context.Products.FindAsync(id);
        if (p == null) return NotFound();

        return new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            ImageUrl = p.ImageUrl
        };
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto dto)
    {
        var p = new Product { Name = dto.Name, Price = dto.Price, Description = dto.Description, ImageUrl = dto.ImageUrl };
        _context.Products.Add(p);
        await _context.SaveChangesAsync();
        dto.Id = p.Id;
        return CreatedAtAction(nameof(GetProduct), new { id = p.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductDto dto)
    {
        var p = await _context.Products.FindAsync(id);
        if (p == null) return NotFound();

        p.Name = dto.Name;
        p.Price = dto.Price;
        p.Description = dto.Description;
        p.ImageUrl = dto.ImageUrl;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var p = await _context.Products.FindAsync(id);
        if (p == null) return NotFound();

        _context.Products.Remove(p);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
