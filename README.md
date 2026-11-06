# OrderHubProject

Учебный проект на C# для работы с заказами, товарами и складом.


## Структура проекта

```text
OrderHubProject/
├── src/
│   └── OrderHub/
│       ├── Domain/           # Модели предметной области
│       │   ├── Order.cs
│       │   ├── Customer.cs
│       │   └── Product.cs
│       ├── Services/           # Бизнес-логика
│       │   ├── OrderService.cs      # Заказы: List, Queue, Stack
│       │   ├── OrderStream.cs       # Итераторы (yield return, IEnumerator)
│       │   ├── CatalogService.cs    # Каталог и сортировка
│       │   ├── ReportService.cs     # LINQ-отчёты
│       │   └── WarehouseService.cs  # Склад: Dictionary
│       ├── Collections/        # Коллекции
│       │   └── CircularBuffer.cs
│       ├── Data/               # Начальные данные
│       │   └── SeedData.cs
│       └── Program.cs          # Точка входа и демонстрация
├── docs/
│   └── report.md             # Отчёт по выполненным этапам
├── OrderHub.sln              # Решение Visual Studio
├── src/OrderHub/OrderHub.csproj
└── README.md
```

## Отчёт

Описание реализации и результаты выполнения заданий находятся в файле [`docs/report.md`](docs/report.md).

## Выполненные этапы

| Этап | КТ | Тема |
|------|-----|------|
| 1 | КТ 31 | Коллекции List<T>, Stack<T>, Queue<T> |
| 2 | КТ 32 | Связный список LinkedList<T> |
| 3 | КТ 33 | Dictionary<TKey, TValue> |
| 4 | КТ 34 | IComparable<T>, IComparer<T>. Сортировка |
| 5 | КТ 35 | LINQ: базовые запросы |
| 6 | КТ 36 | LINQ: проекции, фильтрация, группировка |
| 7 | КТ 37 | LINQ-запросы к коллекциям |
| 8 | КТ 38 | Перечислители и итераторы (yield return) |
| 9 | КТ 39 | Пользовательские итераторы (IEnumerator) |