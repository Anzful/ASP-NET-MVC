using Microsoft.AspNetCore.Mvc;
using OnlineStore.Web.Services;

namespace OnlineStore.Web.Controllers;

public class HomeController : Controller
{
    private readonly ApiService _apiService;

    public HomeController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _apiService.GetProductsAsync();
        return View(products);
    }
}
