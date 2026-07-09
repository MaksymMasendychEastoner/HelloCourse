using lesson_2_block_5.Dto;
using lesson_2_block_5.Mappers;
using lesson_2_block_5.Models;
using System;
using System.Collections.Generic;

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

// ЗАДАЧА 2 — Мапінг сирих даних у DTO
var products = ProductMapper.ToDtoList(rawProducts);
var orders = OrderMapper.ToDtoList(rawOrders);

Console.WriteLine($"Mapped {products.Count} products and {orders.Count} orders to DTO.");

// ЗАДАЧА 3 — LINQ ПО DTO (ПРОДУКТИ)
Console.WriteLine("\n--- PRODUCTS ANALYSIS ---");

// 1. Всі доступні товари, відсортовані за ціною (зростання)
var availableSorted = products.Where(p => p.IsAvailable).OrderBy(p => p.Price);
Console.WriteLine("Available products sorted by price:");
foreach (var p in availableSorted) Console.WriteLine($" - {p.Name}: {p.Price}");

// 2. Товари категорії "Electronics" з ціною нижче 500
var cheapElectronics = products.Where(p => p.Category == "Electronics" && p.Price < 500);
Console.WriteLine("\nElectronics cheaper than 500:");
foreach (var p in cheapElectronics) Console.WriteLine($" - {p.Name}: {p.Price}");

// 3. Середня ціна по кожній категорії
Dictionary<string, decimal> avgPrices = products
    .GroupBy(p => p.Category)
    .ToDictionary(g => g.Key, g => g.Average(p => p.Price));
Console.WriteLine("\nAverage price by category:");
foreach (var kvp in avgPrices) Console.WriteLine($" - {kvp.Key}: {kvp.Value:F2}");

// 4. Найдорожчий товар у кожній категорії (GroupBy + MaxBy)
Dictionary<string, ProductDto?> maxPriceProducts = products
    .GroupBy(p => p.Category)
    .ToDictionary(g => g.Key, g => g.MaxBy(p => p.Price));
Console.WriteLine("\nMost expensive product in category:");
foreach (var kvp in maxPriceProducts) Console.WriteLine($" - {kvp.Key}: {kvp.Value?.Name} ({kvp.Value?.Price})");

// 5. Кількість товарів не в наявності
int outOfStockCount = products.Count(p => !p.IsAvailable);
Console.WriteLine($"\nProducts out of stock: {outOfStockCount}");


// ЗАДАЧА 3 — LINQ ПО DTO (ЗАМОВЛЕННЯ)
Console.WriteLine("\n--- ORDERS ANALYSIS ---");

// 1. Всі замовлення зі статусом Shipped, відсортовані за датою
var shippedOrders = orders
    .Where(o => o.Status == OrderStatus.Shipped)
    .OrderBy(o => o.CreatedAt);
Console.WriteLine("Shipped orders sorted by date:");
foreach (var o in shippedOrders) Console.WriteLine($" - Order #{o.OrderId} at {o.CreatedAt:yyyy-MM-dd} for {o.CustomerName}");

// 2. Кількість замовлень кожного статусу
Dictionary<OrderStatus, int> ordersCountByStatus = orders
    .GroupBy(o => o.Status)
    .ToDictionary(g => g.Key, g => g.Count());
Console.WriteLine("\nOrders count by status:");
foreach (var kvp in ordersCountByStatus) Console.WriteLine($" - {kvp.Key}: {kvp.Value}");

// 3. Замовлення в яких є продукт з Id == 1
var ordersWithProductOne = orders.Where(o => o.ProductIds.Contains(1));
Console.WriteLine("\nOrders containing Product ID 1:");
foreach (var o in ordersWithProductOne) Console.WriteLine($" - Order #{o.OrderId} by {o.CustomerName}");

// 4. CustomerName клієнтів що мають хоча б одне Cancelled замовлення
var customersWithCancelled = orders
    .Where(o => o.Status == OrderStatus.Cancelled)
    .Select(o => o.CustomerName)
    .Distinct()
    .ToList();
Console.WriteLine("\nCustomers with cancelled orders:");
foreach (var name in customersWithCancelled) Console.WriteLine($" - {name}");


// ЗАДАЧА 4 — З'ЄДНАННЯ ДАНИХ
Console.WriteLine("\n--- ADVANCED DATA JOINING ---");

// 4a. Для кожного замовлення зі статусом Shipped: Ім'я клієнта та Загальна сума
var shippedOrdersWithTotals = orders
    .Where(o => o.Status == OrderStatus.Shipped)
    .Select(o => new
    {
        Customer = o.CustomerName,
        OrderId = o.OrderId,
        TotalSum = o.ProductIds.Sum(id => products.FirstOrDefault(p => p.Id == id)?.Price ?? 0)
    });
Console.WriteLine("Shipped orders with total totals:");
foreach (var item in shippedOrdersWithTotals) Console.WriteLine($" - Order #{item.OrderId} by {item.Customer}. Total: {item.TotalSum}");

// 4b. Клієнти, які ніколи не скасовували замовлення
var cancelledCustomers = orders
    .Where(o => o.Status == OrderStatus.Cancelled)
    .Select(o => o.CustomerName)
    .ToHashSet(); 

var loyalCustomers = orders
    .Where(o => !cancelledCustomers.Contains(o.CustomerName))
    .Select(o => o.CustomerName)
    .Distinct()
    .ToList();
Console.WriteLine("\nCustomers who NEVER cancelled an order:");
foreach (var name in loyalCustomers) Console.WriteLine($" - {name}");