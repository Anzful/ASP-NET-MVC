using Microsoft.AspNetCore.Mvc;
using OnlineStore.Web.Services;
using OnlineStore.Shared;

namespace OnlineStore.Web.Controllers;

public class ProductsController : Controller
{
    private readonly ApiService _apiService;

    public ProductsController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _apiService.GetProductAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, string productName, decimal price, int quantity)
    {
        var cartItem = new CartItemDto
        {
            ProductId = productId,
            ProductName = productName,
            Price = price,
            Quantity = quantity
        };

        await _apiService.AddToCartAsync(cartItem);
        return RedirectToAction("Index", "Cart");
    }
}
