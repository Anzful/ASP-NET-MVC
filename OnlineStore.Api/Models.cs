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
            new Product { Id = 1, Name = "MacBook Pro M3", Price = 1999.99m, Description = "The most powerful MacBook ever built with M3 Max chip.", ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 2, Name = "iPhone 15 Pro", Price = 999.99m, Description = "Titanium design, A17 Pro chip, and the best iPhone camera system.", ImageUrl = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 3, Name = "Sony Headphones", Price = 348.00m, Description = "Industry-leading noise canceling headphones with premium sound.", ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 4, Name = "Samsung Galaxy S24", Price = 1299.99m, Description = "Galaxy AI is here. Epic design.", ImageUrl = "https://images.unsplash.com/photo-1610945431683-1bf5a8c43914?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 5, Name = "Dell XPS 15", Price = 1499.00m, Description = "Stunning 3.5K OLED display and high performance for creators.", ImageUrl = "https://images.unsplash.com/photo-1593642632823-8f78536788c6?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 6, Name = "iPad Pro", Price = 1099.00m, Description = "The ultimate iPad experience.", ImageUrl = "https://images.unsplash.com/photo-1544816155-12df9643f363?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 7, Name = "Smart Watch", Price = 799.00m, Description = "The most rugged and capable watch.", ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 8, Name = "Logitech Mouse", Price = 99.99m, Description = "An icon remastered. Quiet clicks.", ImageUrl = "https://images.unsplash.com/photo-1615494937574-0f196bb4af1f?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 9, Name = "Gaming Console", Price = 349.99m, Description = "Next-gen gaming anywhere.", ImageUrl = "https://images.unsplash.com/photo-1605901309584-818e25960b8f?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 10, Name = "Action Camera", Price = 399.99m, Description = "Incredible image quality video stabilization.", ImageUrl = "https://images.unsplash.com/photo-1564466021183-53bc32313620?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 11, Name = "E-Reader", Price = 139.99m, Description = "Now with a 6.8” display.", ImageUrl = "https://images.unsplash.com/photo-1544252654-c9f5ab3747d7?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 12, Name = "Vacuum Cleaner", Price = 749.99m, Description = "Most powerful, intelligent cordless vacuum.", ImageUrl = "https://images.unsplash.com/photo-1558317374-a3594743e9c7?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 13, Name = "Running Shoes", Price = 129.99m, Description = "Comfortable and stylish.", ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 14, Name = "Retro Camera", Price = 1399.00m, Description = "Premium compact digital camera.", ImageUrl = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32?auto=format&fit=crop&w=800&q=80" },
            new Product { Id = 15, Name = "Designer Chair", Price = 1695.00m, Description = "The benchmark for ergonomic seating.", ImageUrl = "https://images.unsplash.com/photo-1592078615290-033ee584e267?auto=format&fit=crop&w=800&q=80" }
        );
    }
}
