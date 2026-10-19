using System.Globalization;

namespace OrderHub.Domain;

public class Order
{

    // ЗАДАЧА: добавьте конструктор с параметрами Id, CustomerName,ProductName, Price, CreatedAt

    public int Id { get; }
    public string CustomerName { get; }
    public string ProductName { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    // ЗАДАЧА: объявите свойства только для чтения: Id, CustomerName, ProductName, Price, CreatedAt
    public Order(int id, string customerName, string productName, decimal price, DateTime createdAt)
    {
        Id = id;
        CustomerName = customerName;
        ProductName = productName;
        Price = price;
        CreatedAt = createdAt;
    }

    // ЗАДАЧА: переопределите ToString() так, чтобы вывод был вида"#12 Иванов — Клавиатура 5 490,00 ₽ (12.03.2026)"
    public override string ToString()
    {
        CultureInfo culture = CultureInfo.GetCultureInfo("ru-RU");

        return $"#{Id} {CustomerName} — {ProductName} " + $"{Price.ToString("N2", culture)} ₽ " + $"({CreatedAt.ToString("dd.MM.yyyy")})";
    }
}
