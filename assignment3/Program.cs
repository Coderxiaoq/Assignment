using System;
using System.Collections.Generic;

public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract bool IsValid();
    public abstract override string ToString();  
}

public class Rectangle : Shape //矩形
{
    public double Length { get; }
    public double Width { get; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override double CalculateArea() => Length * Width;

    public override bool IsValid() => Length > 0 && Width > 0;

    public override string ToString()  
    {
        return $"矩形[长={Length:F2}, 宽={Width:F2}, 面积={CalculateArea():F2}, 合法={IsValid()}]";
    }
}

public class Square : Shape //正方形
{
    public double Side { get; }

    public Square(double side)
    {
        Side = side;
    }

    public override double CalculateArea() => Side * Side;

    public override bool IsValid() => Side > 0;

    public override string ToString()  
    {
        return $"正方形[边长={Side:F2}, 面积={CalculateArea():F2}, 合法={IsValid()}]";
    }
}

public class Triangle : Shape //三角形
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public override double CalculateArea()
    {
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public override bool IsValid() =>
        SideA > 0 && SideB > 0 && SideC > 0 &&
        SideA + SideB > SideC &&
        SideA + SideC > SideB &&
        SideB + SideC > SideA;

    public override string ToString()  
    {
        return $"三角形[边A={SideA:F2}, 边B={SideB:F2}, 边C={SideC:F2}, 面积={CalculateArea():F2}, 合法={IsValid()}]";
    }
}

public static class ShapeFactory //工厂模式
{
    private static readonly Random _random = new();

    public static Shape CreateRandomShape()
    {
        return _random.Next(3) switch
        {
            0 => CreateRandomRectangle(),
            1 => CreateRandomSquare(),
            2 => CreateRandomTriangle(),
            _ => throw new InvalidOperationException()
        };
    }

    private static Shape CreateRandomRectangle()
    {
        return new Rectangle(
            _random.NextDouble() * 10 + 1,
            _random.NextDouble() * 10 + 1
        );
    }

    private static Shape CreateRandomSquare()
    {
        return new Square(_random.NextDouble() * 10 + 1);
    }

    private static Shape CreateRandomTriangle()
    {
        double a = _random.NextDouble() * 10 + 1;
        double b = _random.NextDouble() * 10 + 1;

        double minC = Math.Abs(a - b);
        double maxC = a + b;
        double c = _random.NextDouble() * (maxC - minC) + minC;

        return new Triangle(a, b, c);
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new();
        for (int i = 0; i < 10; i++)
        {
            var shape = ShapeFactory.CreateRandomShape();
            shapes.Add(shape);
            Console.WriteLine($"生成第{i + 1}个图形：{shape}");  // 实时输出每个生成的图形
        }

        double total = 0;
        Console.WriteLine("\n所有图形详细信息：");
        foreach (var shape in shapes)
        {
            total += shape.CalculateArea();
        }
        Console.WriteLine($"\n总面积：{total:F2}");
    }
}