using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderHub.Services;

public class WarehouseService
{
    // ЗАДАЧА: объявите Dictionary<string, int> stock — название товара → количество
    private readonly Dictionary<string, int> stock = new Dictionary<string, int>();

    public void Receive(string productName, int quantity)
    {
        // ЗАДАЧА 1: проверьте наличие товара через TryGetValue
        // ЗАДАЧА 2: если товар есть — увеличьте количество (stock[productName] = existing + quantity)
        // ЗАДАЧА 3: если товара нет — добавьте новую запись через индексатор
        // ЗАДАЧА 4: выведите итоговое количество товара на складе
        if (quantity <= 0)
        {
            Console.WriteLine("Количество поступления должно быть больше нуля.");
            return;
        }

        if (stock.TryGetValue(productName, out int existing))
        {
            stock[productName] = existing + quantity;
        }
        else
        {
            stock[productName] = quantity;
        }

        Console.WriteLine($"Поступление: {productName}. На складе: {stock[productName]} шт.");
    }

    public bool Sell(string productName, int quantity)
    {
        // ЗАДАЧА 1: если товара нет вообще — сообщите об этом и верните false
        if (quantity <= 0)
        {
            Console.WriteLine("Количество продажи должно быть больше нуля.");
            return false;
        }

        if (!stock.TryGetValue(productName, out int existing))
        {
            Console.WriteLine($"Товар \"{productName}\" отсутствует на складе.");
            return false;
        }

        // ЗАДАЧА 2: если товара недостаточно — выведите предупреждение и верните false
        if (existing < quantity)
        {
            Console.WriteLine(
                $"Недостаточно товара \"{productName}\". На складе: {existing} шт., запрошено: {quantity} шт.");
            return false;
        }

        // ЗАДАЧА 3: уменьшите остаток на quantity
        int remaining = existing - quantity;

        // ЗАДАЧА 4: если остаток стал равен нулю — удалите запись через Remove и сообщите, что товар снят с учёта
        if (remaining == 0)
        {
            if (stock.Remove(productName))
            {
                Console.WriteLine($"Товар \"{productName}\" снят с учёта.");
            }
            else
            {
                Console.WriteLine($"Не удалось снять товар \"{productName}\" с учёта.");
                return false;
            }
        }
        else
        {
            stock[productName] = remaining;
            Console.WriteLine($"Продано {quantity} шт. товара \"{productName}\". Остаток: {remaining} шт.");
        }

        // ЗАДАЧА 5: верните true
        return true;
    }

    public bool TryGetStock(string productName, out int quantity)
    {
        // ЗАДАЧА: реализуйте безопасный поиск остатка через TryGetValue
        if (stock.TryGetValue(productName, out quantity))
        {
            return true;
        }

        // ЗАДАЧА: при отсутствии товара присвойте quantity = 0 — значение по умолчанию, чтобы у вызывающего кода не было неинициализированной переменной
        quantity = 0;
        return false;
    }

    public void PrintStock()
    {
        // ЗАДАЧА: переберите склад через foreach по KeyValuePair<string, int>
        // ЗАДАЧА: отсортируйте вывод по алфавиту (OrderBy можно использовать уже сейчас)
        if (stock.Count == 0)
        {
            Console.WriteLine("Склад пуст.");
            return;
        }

        foreach (KeyValuePair<string, int> item in stock.OrderBy(item => item.Key))
        {
            Console.WriteLine($"{item.Key}: {item.Value} шт.");
        }
    }
}
