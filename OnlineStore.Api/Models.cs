using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Api.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public List<OrderItem> Items { get; set; } = new();
}

public class OrderItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
}

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "MacBook Pro M3", Price = 1999.99m, Description = "The most powerful MacBook ever built with M3 Max chip.", ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 2, Name = "iPhone 15 Pro", Price = 999.99m, Description = "Titanium design, A17 Pro chip, and the best iPhone camera system.", ImageUrl = "https://images.unsplash.com/photo-1696446701796-da61225697cc?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 3, Name = "Sony WH-1000XM5", Price = 348.00m, Description = "Industry-leading noise canceling headphones with premium sound.", ImageUrl = "https://images.unsplash.com/photo-1618366712010-f4ae9c647dcb?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 4, Name = "Samsung Galaxy S24 Ultra", Price = 1299.99m, Description = "Galaxy AI is here. Epic titanium design with S Pen.", ImageUrl = "https://images.unsplash.com/photo-1610945431683-1bf5a8c43914?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 5, Name = "Dell XPS 15", Price = 1499.00m, Description = "Stunning 3.5K OLED display and high performance for creators.", ImageUrl = "https://images.unsplash.com/photo-1593642632823-8f78536788c6?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 6, Name = "iPad Pro 12.9", Price = 1099.00m, Description = "The ultimate iPad experience with M2 chip and XDR display.", ImageUrl = "https://images.unsplash.com/photo-1544816155-12df9643f363?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 7, Name = "Apple Watch Ultra 2", Price = 799.00m, Description = "The most rugged and capable Apple Watch. Designed for adventure.", ImageUrl = "https://images.unsplash.com/photo-1695200360811-304c45e85501?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 8, Name = "Logitech MX Master 3S", Price = 99.99m, Description = "An icon remastered. Quiet clicks and 8K DPI tracking.", ImageUrl = "https://images.unsplash.com/photo-1615494937574-0f196bb4af1f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 9, Name = "Nintendo Switch OLED", Price = 349.99m, Description = "7-inch OLED screen, wide adjustable stand, and enhanced audio.", ImageUrl = "https://images.unsplash.com/photo-1679930726265-4d57c31e975a?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 10, Name = "GoPro HERO12 Black", Price = 399.99m, Description = "Incredible image quality, even better HyperSmooth video stabilization.", ImageUrl = "https://images.unsplash.com/photo-1564466021183-53bc32313620?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 11, Name = "Kindle Paperwhite", Price = 139.99m, Description = "Now with a 6.8” display and adjustable warm light.", ImageUrl = "https://images.unsplash.com/photo-1544252654-c9f5ab3747d7?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 12, Name = "Dyson V15 Detect", Price = 749.99m, Description = "Reveals microscopic dust. Most powerful, intelligent cordless vacuum.", ImageUrl = "https://images.unsplash.com/photo-1652870191834-8c832813c9c9?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" }
        );
    }
}
