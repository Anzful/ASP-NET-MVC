using Microsoft.AspNetCore.Mvc;
using OnlineStore.Web.Services;
using OnlineStore.Shared;

namespace OnlineStore.Web.Controllers;

public class OrderController : Controller
{
    private readonly ApiService _apiService;

    public OrderController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var cart = await _apiService.GetCartAsync();
        if (!cart.Any()) return RedirectToAction("Index", "Cart");
        
        var order = new OrderDto { Items = cart };
        return View(order);
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(OrderDto order)
    {
        if (!ModelState.IsValid) return View("Index", order);

        var cart = await _apiService.GetCartAsync();
        order.Items = cart;

        var response = await _apiService.PlaceOrderAsync(order);
        if (response.IsSuccessStatusCode)
        {
            // Clear cart (in our mock API, we should probably add a Clear endpoint, 
            // but for now let's just assume placing an order logic handles it or just show success)
            ViewBag.Message = "Order placed successfully!";
            return View("Success");
        }

        ViewBag.Error = "Failed to place order. Please try again.";
        return View("Index", order);
    }
}
