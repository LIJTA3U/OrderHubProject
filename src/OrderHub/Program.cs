using OrderHub.Services;

var service = new OrderService();

service.CreateOrder("Иванов", "Клавиатура", 5490m);
service.CreateOrder("Петрова", "Монитор", 18990m);
service.CreateOrder("Сидоров", "Мышь", 1290m);

service.ProcessNext();
service.ProcessNext();

service.PrintAllOrders();
service.PrintPendingQueue();
service.PrintRecentActions();

Console.WriteLine();
Console.WriteLine("=== Склад товаров (КТ 33) ===");
var warehouse = new WarehouseService();

warehouse.Receive("Клавиатура", 10);
warehouse.Receive("Клавиатура", 5);     
warehouse.Receive("Монитор", 3);

warehouse.Sell("Монитор", 1);
warehouse.Sell("Монитор", 99);            
warehouse.Sell("Проектор", 1);            
warehouse.PrintStock();