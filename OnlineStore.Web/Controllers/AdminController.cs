using Microsoft.AspNetCore.Mvc;
using OnlineStore.Web.Services;
using OnlineStore.Shared;

namespace OnlineStore.Web.Controllers;

public class AdminController : Controller
{
    private readonly ApiService _apiService;

    public AdminController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _apiService.GetProductsAsync();
        return View(products);
    }

    public IActionResult Create()
    {
        return View(new ProductDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto product)
    {
        if (ModelState.IsValid)
        {
            await _apiService.CreateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _apiService.GetProductAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, ProductDto product)
    {
        if (ModelState.IsValid)
        {
            await _apiService.UpdateProductAsync(id, product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _apiService.DeleteProductAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
