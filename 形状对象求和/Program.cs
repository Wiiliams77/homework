using System;
using System.Collections.Generic;

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
        return IsValid() ? Width * Height : 0;
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

// 工厂类
class ShapeFactory
{
    private static Random rand = new Random();

    public static Shape CreateRandomShape()
    {
        int type = rand.Next(3);
        switch (type)
        {
            case 0: // 生成长方形
                return new Rectangle(rand.Next(1, 10), rand.Next(1, 10));
            case 1: // 生成正方形
                return new Square(rand.Next(1, 10));
            case 2: // 生成三角形
                double a = rand.Next(1, 10);
                double b = rand.Next(1, 10);
                double c = rand.Next(1, (int)(a + b)); // 确保符合三角形规则
                return new Triangle(a, b, c);
            default:
                return null;
        }
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();
        double totalArea = 0;

        // 随机创建 10 个形状
        for (int i = 0; i < 10; i++)
        {
            Shape shape = ShapeFactory.CreateRandomShape();
            if (shape.IsValid())
            {
                shapes.Add(shape);
                totalArea += shape.GetArea();
            }
        }

        // 输出计算结果
        Console.WriteLine($"随机创建 {shapes.Count} 个合法形状，总面积：{totalArea:F2}");
    }
}
