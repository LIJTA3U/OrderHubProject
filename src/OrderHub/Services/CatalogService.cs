using System;
using System.Collections.Generic;
using OrderHub.Domain;

namespace OrderHub.Services;

public class CatalogService
{
    private readonly List<Product> products = new();

    public void AddProduct(string name, decimal price, string category)
    {
        products.Add(new Product(name, price, category));
    }

    // Естественный порядок: от меньшей цены к большей.
    public void PrintSortedByNaturalOrder()
    {
        var sortedProducts = new List<Product>(products);

        sortedProducts.Sort();

        Console.WriteLine();
        Console.WriteLine("Сортировка по цене (IComparable<Product>):");

        foreach (Product product in sortedProducts)
        {
            Console.WriteLine(product);
        }
    }

    // Альтернативный порядок: по названию.
    public void PrintSortedByName()
    {
        var sortedProducts = new List<Product>(products);

        sortedProducts.Sort(new NameComparer());

        Console.WriteLine();
        Console.WriteLine("Сортировка по названию (IComparer<Product>):");

        foreach (Product product in sortedProducts)
        {
            Console.WriteLine(product);
        }
    }

    // Дополнительный пример: по убыванию цены.
    public void PrintSortedByPriceDescending()
    {
        var sortedProducts = new List<Product>(products);

        sortedProducts.Sort(new PriceDescComparer());

        Console.WriteLine();
        Console.WriteLine("Сортировка по убыванию цены (PriceDescComparer):");

        foreach (Product product in sortedProducts)
        {
            Console.WriteLine(product);
        }
    }

    // Разовая сортировка лямбдой по длине названия.
    public void PrintSortedByNameLength()
    {
        var sortedProducts = new List<Product>(products);

        sortedProducts.Sort(
            (a, b) => a.Name.Length.CompareTo(b.Name.Length));

        Console.WriteLine();
        Console.WriteLine(
            "Сортировка по длине названия (Comparison<Product>):");

        Console.WriteLine(
            "Для этой сортировки класс Product не изменялся.");

        foreach (Product product in sortedProducts)
        {
            Console.WriteLine(product);
        }
    }

    // Вывод без сортировки: исходный порядок добавления.
    public void PrintAll()
    {
        Console.WriteLine();
        Console.WriteLine("Каталог в исходном порядке:");

        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }
}