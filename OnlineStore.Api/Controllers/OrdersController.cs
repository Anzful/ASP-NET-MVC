using Microsoft.AspNetCore.Mvc;
using OnlineStore.Api.Models;
using OnlineStore.Shared;

namespace OnlineStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(OrderDto dto)
    {
        if (string.IsNullOrEmpty(dto.CustomerName) || string.IsNullOrEmpty(dto.Address))
        {
            return BadRequest("Customer name and address are required.");
        }

        var order = new Order
        {
            CustomerName = dto.CustomerName,
            Address = dto.Address,
            Phone = dto.Phone,
            Items = dto.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                ProductName = i.ProductName,
                Price = i.Price,
                Quantity = i.Quantity
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Order placed successfully!", OrderId = order.Id });
    }
}
