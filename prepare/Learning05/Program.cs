using System;

class Program
{
    static void Main(string[] args)
    {
        // Square square = new Square("Yellow", 3);
        // Console.WriteLine($"The {square.GetColor()} shape has  an area of {square.GetArea()}.");

        // Rectangle rectangle = new Rectangle("Red", 4, 5);
        // Console.WriteLine($"The {rectangle.GetColor()} shape has  an area of {rectangle.GetArea()}.");

        // Circle circle = new Circle("Green", 6);
        // Console.WriteLine($"The {circle.GetColor()} shape has  an area of {circle.GetArea()}.");
        
        
        List<Shape> shapes = new List<Shape>();
        Square square = new Square("Yellow", 4);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Red", 3, 6);
        shapes.Add(rectangle);

        Circle circle = new Circle("Green", 8);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();

            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has  an area of {area}.");
        }
    }
}