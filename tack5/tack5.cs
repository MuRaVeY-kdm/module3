using System;

namespace tack5
{
    // Класс для сортировки пузыриком
    class BubbleSort
    {
        // Событие для сортировки методом пузырика
        public event EventHandler<int[]> SortBubble;

        // Метод для отправки события с массивом чисел
        public void Bubble(int[] bubble)
        {
            // Проверяем, что событие не равно null перед его вызовом
            SortBubble?.Invoke(this, bubble);
        }
    }

    // Класс для быстрой сортировки
    class SpeedSort
    {
        // Событие для метода быстрой сортировки 
        public event EventHandler<int[]> SortSpeed;

        // Метод для отправки события с массивом чисел
        public void Speed(int[] speed)
        {
            // Проверяем, что событие не равно null перед его вызовом
            SortSpeed?.Invoke(this, speed);
        }
    }

    class tack5
    {
        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        // Обработчик события сортировки пузыриком
        private static void OnBubble(object sender, int[] mas)
        {
            int[] Bubblesort(int[] arr)
            {
                int temp; //переменная для запоминания элементов
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        //если элемент i больше элемента j
                        if (arr[i] > arr[j])
                        {
                            //запомнить эл. i
                            temp = arr[i];
                            //прировнять эл. j к эл. i
                            arr[i] = arr[j];
                            //присвоить эл. j запоп. эл. i
                            arr[j] = temp;
                        }
                    }
                }
                return arr;
            }

            Console.WriteLine("Сортировка пузырьком:");
            mas = Bubblesort(mas);
            PrintArray(mas);
        }

        private static void OnSpeed(object sender, int[] mas)
        {
            // Вложенный метод для быстрой сортировки
            void Speedsort(int[] arr, int left, int right)
            {
                if (left < right)
                {
                    // Вычисление опорного элемента (pivot) и его позиции
                    int pivot = Partition(arr, left, right);

                    // Рекурсивная сортировка для левой и правой частей массива
                    if (pivot > 1)
                        Speedsort(arr, left, pivot - 1);
                    if (pivot + 1 < right)
                        Speedsort(arr, pivot + 1, right);
                }
            }
            int temp; //переменная для запоминания элементов
            // Вложенный метод для разделения массива на две части
            int Partition(int[] arr, int left, int right)
            {
                int pivot = arr[left]; // Опорный элемент (pivot), присвоить левый элю
                while (true)
                {
                    // Находим элементы слева, которые меньше pivot
                    while (arr[left] < pivot)
                        left++;

                    // Находим элементы справа, которые больше pivot
                    while (arr[right] > pivot)
                        right--;

                    if (left < right)
                    {
                        // Если найдены элементы для обмена, меняем их местами
                        if (arr[left] == arr[right])
                            return right;
                        temp = arr[left];
                        arr[left] = arr[right];
                        arr[right] = temp;
                    }
                    else
                    {
                        // Если указатели left и right пересеклись, возвращаем right
                        return right;
                    }
                }
            }

            // Выводим сообщение о том, что выполняется быстрая сортировка
            Console.WriteLine("Быстрая сортировка:");

            // Вызываем метод QuickSort для сортировки массива mas
            Speedsort(mas, 0, mas.Length - 1); //сортировка  массива mas от 0 индекса до последнего-1
            // Выводим отсортированный массив на экран
            PrintArray(mas);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Сколько чисел будем сортировать?");
            int N = Convert.ToInt32(Console.ReadLine());
            int[] mas = new int[N];
            Random rnd = new Random();
            Console.WriteLine("Массив:");
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(-101, 101);
                Console.Write($"{mas[i]} ");
            }
            Console.WriteLine();

            BubbleSort bubblesort = new BubbleSort();
            SpeedSort speedsort = new SpeedSort();

            // Регистрируем обработчики событий
            bubblesort.SortBubble += OnBubble;
            speedsort.SortSpeed += OnSpeed;

            // Выбор какую сортировку использовать (пузырьковую или быструю)
            Console.Write("Какую сортировку использовать (1 - Пузырьковая, 2 - Быстрая): ");
            int number = int.Parse(Console.ReadLine());

            if (number == 1)
            {
                // Вызываем событие сортировки пузырьком
                bubblesort.Bubble(mas);
            }
            else if (number == 2)
            {
                // Вызываем событие быстрой сортировки
                speedsort.Speed(mas);
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }

            Console.ReadLine();
        }
    }
}
