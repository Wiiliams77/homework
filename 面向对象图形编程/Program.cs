using System;

abstract class Shape
{
    public abstract double GetArea();
    public abstract bool IsValid();
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }

    public override bool IsValid()
    {
        return Width > 0 && Height > 0;
    }
}

class Square : Rectangle
{
    public Square(double side) : base(side, side) { }

    public override bool IsValid()
    {
        return Width > 0;
    }
}

class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override double GetArea()
    {
        if (!IsValid()) return 0;
        double s = (A + B + C) / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }

    public override bool IsValid()
    {
        return A > 0 && B > 0 && C > 0 && (A + B > C) && (A + C > B) && (B + C > A);
    }
}

class Program
{
    static void Main()
    {
        Rectangle rect = new Rectangle(4, 5);
        Console.WriteLine($"Rectangle: Valid = {rect.IsValid()}, Area = {rect.GetArea()}");

        Square square = new Square(4);
        Console.WriteLine($"Square: Valid = {square.IsValid()}, Area = {square.GetArea()}");

        Triangle triangle = new Triangle(3, 4, 5);
        Console.WriteLine($"Triangle: Valid = {triangle.IsValid()}, Area = {triangle.GetArea()}");
    }
}