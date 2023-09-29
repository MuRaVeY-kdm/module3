using System;

namespace tack2
{
    // Класс для уведомлений
    class Notification
    {
        // Событие для отправки сообщения
        public event EventHandler<string> SentMessage;

        // Событие для совершения звонка
        public event EventHandler<string> MadeCall;

        // Событие для отправки электронного письма
        public event EventHandler<string> SentEmail;

        // Метод для отправки сообщения
        public void Message(string message)
        {
            //если значение не равно null операция выполняется
            SentMessage?.Invoke(this, message);
        }

        // Метод для совершения звонка
        public void Call(string phoneNumber)
        {
            //если значение не равно null операция выполняется
            MadeCall?.Invoke(this, phoneNumber);
        }

        // Метод для отправки электронного письма
        public void Email(string emailAddress)
        {
            //если значение не равно null операция выполняется
            SentEmail?.Invoke(this, emailAddress);
        }
    }

    class Program
    {
        // Обработчик события отправки сообщения
        private static void OnMessage(object sender, string message)
        {
            Console.WriteLine($"Сообщение отправлено: {message}");
        }

        // Обработчик события совершения звонка
        private static void OnCall(object sender, string phoneNumber)
        {
            Console.WriteLine($"Звонок совершен на номер: {phoneNumber}");
        }

        // Обработчик события отправки электронного письма
        private static void OnEmail(object sender, string emailAddress)
        {
            Console.WriteLine($"Электронное письмо отправлено на адрес: {emailAddress}");
        }

        static void Main()
        {
            Notification notification = new Notification();

            // Регистрируем обработчики событий
            notification.SentMessage += OnMessage;
            notification.MadeCall += OnCall;
            notification.SentEmail += OnEmail;

            // Примеры использования
            notification.Message("Привет, как дела?");
            notification.Call("+1234567890");
            notification.Email("example@example.com");

            Console.ReadLine();
        }
    }

}
