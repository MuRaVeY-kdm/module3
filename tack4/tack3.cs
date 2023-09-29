using System;
using System.Collections.Generic;

namespace tack3
{
    // Класс для уведомлений
    class Notification
    {
        // Событие для отправки сообщения
        public event EventHandler<string> SentNotice;

        // Метод для отправки сообщения
        public void Notice(string notice)
        {
            //если значение не равно null операция выполняется
            SentNotice?.Invoke(this, notice);
        }
    }

    class Recording
    {
        // Событие для записи в журнал
        public event EventHandler<string> LogEntry;

        // Метод для отправки сообщения
        public void Record(string record)
        {
            //если значение не равно null операция выполняется
            LogEntry?.Invoke(this, record);
        }
    }
    class tack3
    {
        // Обработчик события отправки сообщения
        private static void OnNotice(object sender, string notice)
        {
            Console.WriteLine($"Уведомление отправлено: {notice}");
        }

        // Обработчик события записи в журнал
        private static void OnRecord(object sender, string record)
        {
            Console.WriteLine($"Записанно в журнал: {record}");
        }

        static void Main()
        {
            Notification notification = new Notification();
            Recording recording = new Recording();

            // Регистрируем обработчики событий
            notification.SentNotice += OnNotice;
            recording.LogEntry += OnRecord;

            Console.Write("Введите текст: ");
            string text = Console.ReadLine();

            // Выбор что делать
            Console.Write("Что сделать с текстом (1 - Уведомление, 2 - Записать в журнал): ");
            int number = int.Parse(Console.ReadLine());

            // В зависимости от выбора пользователя, вызываем событие
            if (number == 1)
            {
                // событие "уведомить"
                notification.Notice(text);
            }
            else if (number == 2)
            {
                // событие "Запись"
                recording.Record(text);
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }
            Console.ReadLine();
            return;
        }
    }
}
