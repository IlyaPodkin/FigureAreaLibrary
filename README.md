# Тестовое задание Mindbox

## Описание библиотеки FigureAreaLibrary из 1 задания

### Описание

`FigureAreaLibrary` — библиотека для вычисления площадей круга и треугольника, а также проверки корректности параметров и определения, является ли треугольник прямоугольным.

### Содержание и функциональность

- Юнит-тесты
    
- Легкость добавления других фигур
    
- Вычисление площади фигуры без знания типа фигуры в compile-time
    
- Проверку на то, является ли треугольник прямоугольным

### Структура

- **`IShape`** — интерфейс для фигур с методом `GetShapeArea()`.
- **`Circle`** — класс для круга, реализующий `IShape`.
- **`Triangle`** — класс для треугольника, реализующий `IShape`.
- **`CalculationShapeArea`** — утилитный класс для вычисления площади через `IShape`.

### Тесты

Для проверки функциональности библиотеки разработаны юнит-тесты, которые охватывают следующие сценарии:

- Проверка правильности вычисления площади круга с положительным радиусом.
- Проверка обработки отрицательных значений радиуса для круга.
- Проверка правильности вычисления площади треугольника по трем сторонам.
- Проверка обработки некорректных сторон для треугольников.
- Проверка, является ли треугольник прямоугольным.

Тесты находятся в проекте **`FigureAreaTests`** и используют **xUnit**.

## Выполнение 2 задания

Для внесения ясности при проверки данного задания я также прикрепляю запросы для создания таблиц и заполнения их данными.

### Создание таблиц
```sql
-- Создание таблицы Products
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,        
    ProductName VARCHAR(255) NOT NULL   
);

-- Создание таблицы Categories
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,         
    CategoryName VARCHAR(255) NOT NULL   
);

-- Создание таблицы ProductCategories (связующая таблица)
CREATE TABLE ProductCategories (
    ProductID INT,                      
    CategoryID INT,                     
    PRIMARY KEY (ProductID, CategoryID), -- Составной первичный ключ
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),   -- Внешний ключ на Products
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) -- Внешний ключ на Categories
);
```
### Добавление записей в таблицы
```sql
-- Добавление данных в таблицу Products
INSERT INTO Products (ProductID, ProductName) VALUES
(1, 'Tomato'),
(2, 'Apple'),
(3, 'Watermelon');

-- Добавление данных в таблицу Categories
INSERT INTO Categories (CategoryID, CategoryName) VALUES
(1, 'Vegetables'),
(2, 'Fruits');

-- Добавление данных в таблицу ProductCategories
INSERT INTO ProductCategories (ProductID, CategoryID) VALUES
(1, 1),
(2, 2);
```

SQL-запрос:

```sql
SELECT Products.ProductName, Categories.CategoryName
FROM Products
LEFT JOIN ProductCategories ON Products.ProductID = ProductCategories.ProductID
LEFT JOIN Categories ON ProductCategories.CategoryID = Categories.CategoryID;
```

### Объяснение:

1. **Таблицы**:
    
    - `Products`: содержит информацию о продуктах.
    - `Categories`: содержит информацию о категориях.
    - `ProductCategories`: связывает продукты и категории, представляя собой таблицу связей (многие-ко-многим), с колонками `ProductID` и `CategoryID`.
2. **SQL-запрос**:
    
    - C помощью связки таблиц `Products` и `ProductCategories` и операции `LEFT JOIN` мы получаем вывод записей - всех пар «Имя продукта – Имя категории». Приэтом, если у продукта нет категории, его имя всё равно будет включено в результат, но поле `CategoryName` будет содержать значение `NULL`.



### Пример данных:

#### Таблица `Products`:

| ProductID | ProductName |
| --------- | ----------- |
| 1         | Tomato      |
| 2         | Apple      |
| 3         | Watermelon  |

#### Таблица `Categories`:

| CategoryID | CategoryName |
| ---------- | ------------ |
| 1          | Vegetables   |
| 2          | Fruits       |

#### Таблица `ProductCategories`:

|ProductID|CategoryID|
|---|---|
|1|1|
|2|2|

### Ожидаемый результат:

|ProductName|CategoryName|
|---|---|
|Tomato|Vegetables|
|Apple|Fruits|
|Watermelon|NULL|

