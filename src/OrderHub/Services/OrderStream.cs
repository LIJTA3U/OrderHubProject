using OrderHub.Domain;
using System;
using System.Collections.Generic;

namespace OrderHub.Services;

public class OrderStream
{
    private readonly List<Order> _orders;

    public OrderStream(List<Order> orders)
    {
        _orders = orders ?? throw new ArgumentNullException(nameof(orders));
    }

    // Задача 1: реализуйте итератор, возвращающий все заказы по очереди
    // Используйте yield return для ленивого последовательного возврата элементов
    public IEnumerable<Order> GetAllOrders()
    {
        foreach (var order in _orders)
        {
            yield return order;
        }
    }

    // Задача 2: реализуйте итератор, возвращающий заказы указанного клиента
    // Фильтрация выполняется лениво — только при переборе результата
    public IEnumerable<Order> GetOrdersByCustomer(string customerName)
    {
        foreach (var order in _orders)
        {
            if (string.Equals(order.CustomerName, customerName, StringComparison.OrdinalIgnoreCase))
            {
                yield return order;
            }
        }
    }

    // Задача 3: реализуйте итератор, возвращающий заказы дороже указанной суммы
    public IEnumerable<Order> GetOrdersAbovePrice(decimal minPrice)
    {
        foreach (var order in _orders)
        {
            if (order.Price > minPrice)
            {
                yield return order;
            }
        }
    }

    // Задача 4: реализуйте итератор, возвращающий заказы в обратном порядке
    public IEnumerable<Order> GetOrdersReversed()
    {
        for (int i = _orders.Count - 1; i >= 0; i--)
        {
            yield return _orders[i];
        }
    }
}
