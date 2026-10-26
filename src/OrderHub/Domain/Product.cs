using System;
using System.Collections.Generic;

namespace OrderHub.Domain;

public class Product : IComparable<Product>
{

    // ЗАДАЧА: объявите конструктор с параметрами Name, Price, Category
    // ЗАДАЧА: переопределите свойства, чтобы они были только для чтения(private set)

    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Category { get; private set; }

    public Product(string name, decimal price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public int CompareTo(Product? other)
    {

        // ЗАДАЧА: верните результат сравнения по цене — естественный порядок
        if (other is null)
        {
            return 1;
        }

        return Price.CompareTo(other.Price);
    }
    // ЗАДАЧА: объявите класс NameComparer : IComparer<Product>
    // ЗАДАЧА: реализуйте метод Compare так, чтобы сортировка шла по алфавиту названий

    public override string ToString() =>
        $"{Name} — {Price:0.00} ₽ ({Category})";
}

public class NameComparer : IComparer<Product>
{
    public int Compare(Product? a, Product? b)
    {
        if (ReferenceEquals(a, b))
        {
            return 0;
        }

        if (a is null)
        {
            return -1;
        }

        if (b is null)
        {
            return 1;
        }

        return string.Compare(
            a.Name,
            b.Name,
            StringComparison.Ordinal);
    }
}

// ЗАДАЧА: объявите класс PriceDescComparer : IComparer<Product> — по убыванию цены

public class PriceDescComparer : IComparer<Product>
{
    public int Compare(Product? a, Product? b)
    {
        if (ReferenceEquals(a, b))
        {
            return 0;
        }

        if (a is null)
        {
            return -1;
        }

        if (b is null)
        {
            return 1;
        }

        return b.Price.CompareTo(a.Price);
    }
}