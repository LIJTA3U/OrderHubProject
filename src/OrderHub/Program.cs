using OrderHub.Domain;
using OrderHub.Services;
using System;
using System.Collections.Generic;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var products = new List<Product>
{
    new Product("Клавиатура", 5490m, "Периферия"),
    new Product("Монитор", 18990m, "Мониторы"),
    new Product("Мышь", 1290m, "Периферия"),
    new Product("Наушники", 7990m, "Аудио"),
    new Product("Кабель", 690m, "Аксессуары"),
    new Product("Чип", 490m, "Комплектующие"),
};

var reports = new ReportService();

const decimal threshold = 5000m;

Console.WriteLine("=== КТ 35. Базовые запросы LINQ ===");

var list = reports.ExpensiveProducts(products, threshold);

foreach (string line in list)
{
    Console.WriteLine(line);
}

Console.WriteLine(reports.CountExpensive(products, threshold));
Console.WriteLine(reports.HasVeryExpensive(products, 50000m));
Console.WriteLine(reports.AllInStock(products));
Console.WriteLine(reports.Cheapest(products));

Console.WriteLine();

Console.WriteLine("=== КТ 36. Сводка по категориям ===");

var summary = reports.SummarizeByCategory(products);

foreach (var row in summary)
{
    Console.WriteLine($"{row.Category}: {row.Count} шт., средняя {row.AveragePrice:0.00} ₽");
}

Console.WriteLine();

var expensiveCategory = reports.MostExpensiveCategory(products);

Console.WriteLine($"Самая дорогая категория: {expensiveCategory.Category}");
Console.WriteLine($"Средняя цена: {expensiveCategory.AveragePrice:0.00} ₽");

Console.WriteLine();

Console.WriteLine("Категории, где товаров не меньше двух:");

var categories = reports.CategoriesWithAtLeast(products, 2);

foreach (string category in categories)
{
    Console.WriteLine(category);
}

Console.WriteLine();
Console.WriteLine("=== КТ 37. LINQ-запросы к коллекциям ===");

var customers = new List<Customer>
{
    new Customer(1, "Иванов", "Москва"),
    new Customer(2, "Петрова", "Санкт-Петербург"),
    new Customer(3, "Сидоров", "Казань"),
    new Customer(4, "Смирнова", "Москва")
};

var orderService = new OrderService();

var orders = new List<Order>
{
    orderService.CreateOrder("Иванов", "Клавиатура", 5490m),
    orderService.CreateOrder("Петрова", "Монитор", 18990m),
    orderService.CreateOrder("Сидоров", "Мышь", 1290m),
    orderService.CreateOrder("Иванов", "Наушники", 7990m),
    orderService.CreateOrder("Петрова", "Чип", 490m),
    orderService.CreateOrder("Сидоров", "Монитор", 18990m),
    orderService.CreateOrder("Смирнова", "Кабель", 690m),
    orderService.CreateOrder("Иванов", "Мышь", 1290m)
};

Console.WriteLine("Топ-3 клиента по сумме заказов:");

var topCustomers = reports.TopCustomers(customers, orders, 3);

foreach (string customer in topCustomers)
{
    Console.WriteLine(customer);
}

Console.WriteLine();

Console.WriteLine("Общая выручка за 2026 год:");

Console.WriteLine(
    reports.TotalRevenueByYear(orders, 2026).ToString("0.00")
);

Console.WriteLine();

Console.WriteLine("Клиент с наибольшим числом заказов:");

Console.WriteLine(reports.CustomerWithMostOrders(orders));

Console.WriteLine();

Console.WriteLine("Заказы выше средней стоимости:");

var aboveAverage = reports.OrdersAboveAverage(orders);

foreach (Order order in aboveAverage)
{
    Console.WriteLine(order);
}