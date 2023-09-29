using System;
using System.Collections.Generic;

namespace tack4
{
    // Класс для хранения данных
    class DataItem
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Keywords { get; set; }
    }

    // Класс для фильтрации данных
    class Filter
    {
        // Делегат для определения условия фильтрации
        public delegate bool FilterCondition(DataItem item);

        // Метод для фильтрации данных с использованием делегата
        public static List<DataItem> FilterData(List<DataItem> data, FilterCondition condition)
        {
            List<DataItem> filteredData = new List<DataItem>();
            foreach (var item in data)
            {
                // Проверяем, соответствует ли элемент условиям фильтрации
                if (condition(item))
                {
                    filteredData.Add(item);
                }
            }
            return filteredData;
        }
    }

    class tack4
    {
        static void Main()
        {
            // Создаем список данных
            List<DataItem> data = new List<DataItem>
            {
                new DataItem { Name = "Item1", Date = DateTime.Parse("2023-09-28"), Keywords = "apple, banana" },
                new DataItem { Name = "Item2", Date = DateTime.Parse("2023-09-29"), Keywords = "banana, cherry" },
                new DataItem { Name = "Item3", Date = DateTime.Parse("2023-09-30"), Keywords = "apple, cherry" }
            };

            // Выбираем тип фильтрации (по дате или по ключевым словам)
            Console.WriteLine("Выберите тип фильтрации (1 - по дате, 2 - по ключевым словам):");
            int number = int.Parse(Console.ReadLine());

            List<DataItem> filteredData;

            // В зависимости от выбора пользователя, создаем соответствующий делегат фильтрации
            if (number == 1)
            {
                Console.WriteLine("Введите дату для фильтрации (гггг-мм-дд):");
                DateTime filterDate = DateTime.Parse(Console.ReadLine());

                // Фильтр по дате
                Filter.FilterCondition dateFilter = item => item.Date == filterDate;
                filteredData = Filter.FilterData(data, dateFilter);
            }
            else if (number == 2)
            {
                Console.WriteLine("Введите ключевые слова для фильтрации:");
                string filterKeywords = Console.ReadLine();

                // Фильтр по ключевым словам
                Filter.FilterCondition keywordFilter = item => item.Keywords.Contains(filterKeywords);
                filteredData = Filter.FilterData(data, keywordFilter);
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }

            // Вывод результатов фильтрации
            Console.WriteLine("Результаты фильтрации:");
            foreach (var item in filteredData)
            {
                Console.WriteLine($"Name: {item.Name}, Date: {item.Date}, Keywords: {item.Keywords}");
            }
            Console.ReadLine();
        }
    }
}
