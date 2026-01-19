using System.Net.Http.Json;
using OnlineStore.Shared;

namespace OnlineStore.Web.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Products
    public async Task<List<ProductDto>> GetProductsAsync() => 
        await _httpClient.GetFromJsonAsync<List<ProductDto>>("api/products") ?? new();

    public async Task<ProductDto?> GetProductAsync(int id) => 
        await _httpClient.GetFromJsonAsync<ProductDto>($"api/products/{id}");

    public async Task CreateProductAsync(ProductDto product) => 
        await _httpClient.PostAsJsonAsync("api/products", product);

    public async Task UpdateProductAsync(int id, ProductDto product) => 
        await _httpClient.PutAsJsonAsync($"api/products/{id}", product);

    public async Task DeleteProductAsync(int id) => 
        await _httpClient.DeleteAsync($"api/products/{id}");

    // Cart
    public async Task<List<CartItemDto>> GetCartAsync() => 
        await _httpClient.GetFromJsonAsync<List<CartItemDto>>("api/cart") ?? new();

    public async Task AddToCartAsync(CartItemDto item) => 
        await _httpClient.PostAsJsonAsync("api/cart", item);

    public async Task UpdateCartQuantityAsync(int productId, int quantity) => 
        await _httpClient.PutAsJsonAsync($"api/cart/{productId}", quantity);

    public async Task RemoveFromCartAsync(int productId) => 
        await _httpClient.DeleteAsync($"api/cart/{productId}");

    // Orders
    public async Task<HttpResponseMessage> PlaceOrderAsync(OrderDto order) => 
        await _httpClient.PostAsJsonAsync("api/orders", order);
}
