using OrderHub.Domain;
using System;
using System.Collections;
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

    // Задача 5: пользовательский перечислитель без yield return
    // Реализуйте IEnumerator<Order> вручную: MoveNext, Current, Reset, Dispose
    public IEnumerable<Order> GetCustomOrders()
    {
        return new OrderEnumerator(_orders);
    }

    // Пользовательский перечислитель заказов (реализация IEnumerable + IEnumerator без yield return)
    private class OrderEnumerator : IEnumerable<Order>, IEnumerator<Order>
    {
        private readonly List<Order> _orders;
        private int _position = -1;

        public OrderEnumerator(List<Order> orders)
        {
            _orders = orders;
        }

        // Задача 5.6: вернуть самого себя как IEnumerable<Order> для использования в foreach
        public IEnumerator<Order> GetEnumerator()
        {
            Reset();
            return this;
        }

        // Задача 5.7: нетипизированный GetEnumerator для IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Задача 5.1: переместить курсор на следующий элемент
        public bool MoveNext()
        {
            _position++;
            return _position < _orders.Count;
        }

        // Задача 5.2: вернуть текущий элемент
        public Order Current => _orders[_position];

        // Задача 5.3: нетипизированный Current для IEnumerator
        object? IEnumerator.Current => Current;

        // Задача 5.4: сбросить перечислитель в начальное положение
        public void Reset()
        {
            _position = -1;
        }

        // Задача 5.5: освободить ресурсы
        public void Dispose()
        {
            // Нет неуправляемых ресурсов
        }
    }
}
