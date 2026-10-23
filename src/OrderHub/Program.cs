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

Console.WriteLine();
Console.WriteLine("=== Каталог товаров (КТ 34) ===");

var catalog = new CatalogService();

// Добавляем товары в каталог.
catalog.AddProduct("Клавиатура", 5490m, "Периферия");
catalog.AddProduct("Монитор", 18990m, "Мониторы");
catalog.AddProduct("Мышь", 1290m, "Периферия");
catalog.AddProduct("Наушники", 7990m, "Аудио");
catalog.AddProduct("Кабель", 690m, "Аксессуары");
catalog.AddProduct("Чип", 490m, "Комплектующие");

// Исходный порядок добавления.
catalog.PrintAll();

// Этап 4: три требуемых способа сортировки.
catalog.PrintSortedByNaturalOrder();
catalog.PrintSortedByName();
catalog.PrintSortedByNameLength();

// Дополнительная сортировка через PriceDescComparer.
catalog.PrintSortedByPriceDescending();

// Проверяем, что исходный порядок не изменился.
catalog.PrintAll();