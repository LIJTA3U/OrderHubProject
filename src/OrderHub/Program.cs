using OrderHub.Domain;
using OrderHub.Services;
using System;
using System.Collections.Generic;

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
var list = reports.ExpensiveProducts(products, threshold);
foreach (string line in list)
{
    Console.WriteLine(line);
}
Console.WriteLine(reports.CountExpensive(products, threshold));
Console.WriteLine(reports.HasVeryExpensive(products, 50000m));
Console.WriteLine(reports.AllInStock(products));
Console.WriteLine(reports.Cheapest(products));