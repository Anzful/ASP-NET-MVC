using Microsoft.AspNetCore.Mvc;
using OnlineStore.Web.Services;

namespace OnlineStore.Web.Controllers;

public class CartController : Controller
{
    private readonly ApiService _apiService;

    public CartController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var cart = await _apiService.GetCartAsync();
        return View(cart);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateQuantity(int productId, int quantity)
    {
        await _apiService.UpdateCartQuantityAsync(productId, quantity);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int productId)
    {
        await _apiService.RemoveFromCartAsync(productId);
        return RedirectToAction("Index");
    }
}
