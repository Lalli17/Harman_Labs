using System.Drawing;

namespace Inheritance_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();
            Circle circle = new Circle();
            circle.Radius = 5;
            shapes.Add(circle);

            Rectangle rectangle = new Rectangle();
            rectangle.Length = 4;
            rectangle.Breadth = 6;
            shapes.Add(rectangle);

            Triangle triangle = new Triangle();
            triangle.Base = 3;
            triangle.Height = 8;
            shapes.Add(triangle);

            foreach(IShape shape in shapes)
                {
                Console.WriteLine($"Area:{shape.Calculatevalue()}");
                }
        }
    }

    interface IShape
    {
       double Calculatevalue();
    }
    class Circle : IShape
    {
        public double Radius { get; set; }
        public double Calculatevalue() =>3.14*Radius*Radius;
    }

    class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public double Calculatevalue() => 0.5*Base*Height;

    }

    class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public double Calculatevalue()=> Length*Breadth;
    }

}
