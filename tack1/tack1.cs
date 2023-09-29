using System;


namespace tack1
{
    // Базовый класс "Фигура"
    class Shape
    {
        public virtual double CalculateArea()
        {
            return 0.0;
        }
    }

    // Производный класс "Круг"
    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    // Производный класс "Прямоугольник"
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    // Производный класс "Треугольник"
    class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            BaseLength = baseLength;
            Height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * BaseLength * Height;
        }
    }

    class tack1
    {
        static void Main()
        {
            // Создание делегата для вызова метода CalculateArea
            Func<Shape, double> Delegate = shape => shape.CalculateArea();

            // Создание экземпляров разных фигур
            Circle circle = new Circle(5.0);
            Rectangle rectangle = new Rectangle(4.0, 6.0);
            Triangle triangle = new Triangle(3.0, 4.0);

            // Вызов метода CalculateArea с использованием делегата
            Console.WriteLine($"Площадь круга: {Delegate(circle)}");
            Console.WriteLine($"Площадь прямоугольника: {Delegate(rectangle)}");
            Console.WriteLine($"Площадь треугольника: {Delegate(triangle)}");
            Console.ReadLine();
        }
    }

}
