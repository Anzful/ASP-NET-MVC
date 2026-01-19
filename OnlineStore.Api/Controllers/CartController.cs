using Microsoft.AspNetCore.Mvc;
using OnlineStore.Shared;

namespace OnlineStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    // For simplicity in this exam task, we'll use a static list to simulate a session-based cart.
    // In a real app, this would be in Redis, Session, or a DB.
    private static readonly List<CartItemDto> _cart = new();

    [HttpGet]
    public ActionResult<IEnumerable<CartItemDto>> GetCart()
    {
        return Ok(_cart);
    }

    [HttpPost]
    public ActionResult AddToCart(CartItemDto item)
    {
        var existing = _cart.FirstOrDefault(c => c.ProductId == item.ProductId);
        if (existing != null)
        {
            existing.Quantity += item.Quantity;
        }
        else
        {
            _cart.Add(item);
        }
        return Ok();
    }

    [HttpPut("{productId}")]
    public IActionResult UpdateQuantity(int productId, [FromBody] int quantity)
    {
        var item = _cart.FirstOrDefault(c => c.ProductId == productId);
        if (item == null) return NotFound();
        item.Quantity = quantity;
        return NoContent();
    }

    [HttpDelete("{productId}")]
    public IActionResult RemoveFromCart(int productId)
    {
        var item = _cart.FirstOrDefault(c => c.ProductId == productId);
        if (item == null) return NotFound();
        _cart.Remove(item);
        return NoContent();
    }
}
