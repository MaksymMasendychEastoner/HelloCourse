using System;
using System.Collections.Generic;
using lesson_2_block_5.Models;

Console.WriteLine("--- Internet Shop Data Init ---");

// Тестові дані
var rawProducts = new List<RawProduct>
{
    new() { Id = 1,  Name = "Laptop",       CategoryName = "Electronics", PriceUsd = 999.99, StockCount = 5,  IsActive = true  },
    new() { Id = 2,  Name = "Phone",        CategoryName = "Electronics", PriceUsd = 499.99, StockCount = 12, IsActive = true  },
    new() { Id = 3,  Name = "Headphones",   CategoryName = "Electronics", PriceUsd = 79.99,  StockCount = 0,  IsActive = true  },
    new() { Id = 4,  Name = "T-Shirt",      CategoryName = "Clothing",    PriceUsd = 19.99,  StockCount = 50, IsActive = true  },
    new() { Id = 5,  Name = "Jeans",        CategoryName = "Clothing",    PriceUsd = 49.99,  StockCount = 30, IsActive = false },
    new() { Id = 6,  Name = "Coffee Maker", CategoryName = "Kitchen",     PriceUsd = 89.99,  StockCount = 8,  IsActive = true  },
    new() { Id = 7,  Name = "Blender",      CategoryName = "Kitchen",     PriceUsd = 39.99,  StockCount = 0,  IsActive = true  },
    new() { Id = 8,  Name = "Desk Lamp",    CategoryName = "Office",      PriceUsd = 24.99,  StockCount = 20, IsActive = true  },
};

var rawOrders = new List<RawOrder>
{
    new() { OrderId = 101, CustomerId = 1, CustomerName = "Alice",   ProductIds = new() { 1, 3 },    Status = "shipped",   CreatedAt = new DateTime(2024, 1, 10) },
    new() { OrderId = 102, CustomerId = 2, CustomerName = "Bob",     ProductIds = new() { 2, 4, 6 }, Status = "pending",   CreatedAt = new DateTime(2024, 2, 5)  },
    new() { OrderId = 103, CustomerId = 1, CustomerName = "Alice",   ProductIds = new() { 5 },       Status = "cancelled", CreatedAt = new DateTime(2024, 2, 20) },
    new() { OrderId = 104, CustomerId = 3, CustomerName = "Charlie", ProductIds = new() { 1, 2 },    Status = "shipped",   CreatedAt = new DateTime(2024, 3, 1)  },
    new() { OrderId = 105, CustomerId = 2, CustomerName = "Bob",     ProductIds = new() { 8 },       Status = "pending",   CreatedAt = new DateTime(2024, 3, 15) },
};

Console.WriteLine($"Loaded {rawProducts.Count} raw products and {rawOrders.Count} raw orders.");