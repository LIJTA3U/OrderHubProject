using OrderHub.Domain;

namespace OrderHub.Services;

public class OrderService
{
    // Коллекции для хранения заказов и истории действий
    private readonly List<Order> allOrders = new();
    private readonly Queue<Order> pendingQueue = new();
    private readonly Stack<string> undoHistory = new();

    // Счётчик идентификаторов заказов
    private int nextOrderId = 0;

    public Order CreateOrder(string customerName, string productName, decimal price)
    {
        // Задача 1: создаём новый заказ с уникальным Id
        var order = new Order(
           ++nextOrderId,
           customerName,
           productName,
           price,
           DateTime.Now
       );

        // Задача 2: добавляем заказ в общий список
        allOrders.Add(order);

        // Задача 3: добавляем заказ в очередь ожидания
        pendingQueue.Enqueue(order);

        // Задача 4: сохраняем действие в истории
        undoHistory.Push($"Создан заказ {order.Id} для {customerName}");

        // Задача 5: возвращаем заказ
        return order;
    }

    public Order? ProcessNext()
    {
        // Задача 1: проверяем, есть ли заказы в очереди
        if (pendingQueue.Count == 0)
        {
            return null;
        }

        // Задача 2: извлекаем первый заказ из очереди
        Order order = pendingQueue.Dequeue();

        // Задача 3: записываем действие в историю
        undoHistory.Push($"Обработан заказ {order.Id}");

        // Задача 4: выводим информацию в консоль
        Console.WriteLine($"Обработан заказ: {order}");

        // Задача 5: возвращаем обработанный заказ
        return order;
    }

    public bool UndoLastAction()
    {
        // Задача 1: проверяем, есть ли действия в истории
        if (undoHistory.Count == 0)
        {
            return false;
        }

        // Задача 2: извлекаем последнее действие
        string action = undoHistory.Pop();

        // Задача 3: выводим отменённое действие
        Console.WriteLine($"Отменено действие: {action}");

        return true;
    }

    // Отчёт 1: вывод всех заказов в порядке добавления
    public void PrintAllOrders()
    {
        Console.WriteLine("Все заказы:");

        if (allOrders.Count == 0)
        {
            Console.WriteLine("Заказов нет.");
            return;
        }

        foreach (Order order in allOrders)
        {
            Console.WriteLine(order);
        }
    }

    // Отчёт 2: информация об очереди ожидающих заказов
    public void PrintPendingQueue()
    {
        Console.WriteLine($"Заказов ожидает обработки: {pendingQueue.Count}");

        if (pendingQueue.Count == 0)
        {
            Console.WriteLine("Очередь пуста.");
            return;
        }

        // Peek возвращает первый заказ, не удаляя его
        Console.WriteLine($"Первый в очереди: {pendingQueue.Peek()}");

        // Перебираем все заказы в порядке поступления
        Console.WriteLine("Все заказы в очереди:");

        foreach (Order order in pendingQueue)
        {
            Console.WriteLine(order);
        }
    }

    // Отчёт 3: вывод истории действий от последнего к первому
    public void PrintRecentActions()
    {
        Console.WriteLine("История последних действий:");

        if (undoHistory.Count == 0)
        {
            Console.WriteLine("История пуста.");
            return;
        }

        foreach (string action in undoHistory)
        {
            Console.WriteLine(action);
        }
    }
}