using System;
using System.Collections.Generic;

/*
Code Challenge #4 
This week we'll be doing some code inspection based on the SOLID principles.  Below you will find a code snippet that violates at least one of the SOLID principles.  Your challenge is to identify which of the SOLID principles it violates.  An extra point will be given if you refactor the code so that it follows good object oriented design. http://en.wikipedia.org/wiki/SOLID_(object-oriented_design)
 
public double Area(object[] shapes)
{
    double area = 0;
    foreach (var shape in shapes)  {
        if (shape is Rectangle)  {
            Rectangle rectangle = (Rectangle) shape;
            area += rectangle.Width*rectangle.Height;
        } else {
            Circle circle = (Circle)shape;
            area += circle.Radius * circle.Radius * Math.PI;
        }
    }
 
    return area;
}*/

namespace CodeChallenge04_SOLIDShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // original code above violates Separation of Concerns & Liskov Substitution principle
            // See Area() function below for refactored code

            var shapes = new List<IShape>();
            shapes.Add(new Rectangle(5, 5));
            shapes.Add(new Circle(8));
            shapes.Add(new Square(10));

            LogShapeData(shapes);
            Console.WriteLine("\nTotal Area is: " + Area(shapes));
            Console.ReadKey();
        }

        public static double Area(List<IShape> shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Area();
            }
            return area;
        }

        public static void LogShapeData(List<IShape> shapes)
        {
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ShapeDataDump);
            }
        }
    }

    public interface IShape
    {
        //properties
        double Width { get; set; }
        double Height { get; set; }
        string ShapeDataDump { get; }

        //methods
        double Area();
    }

    public class Rectangle : IShape
    {
        //properties
        public double Width {get; set;}
        public double Height {get; set;}
        public string ShapeDataDump {
            get
            {
                return String.Format("Rectangle ({0}x{1}) Area:{2}", this.Width, this.Height, Area());
            }
        }

        //methods
        public double Area()
        {
            return this.Width * this.Height;
        }

        //constructors
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }

    public class Circle : IShape
    {
        //properties
        public double Width { get; set; }
        public double Height
        {
            get
            {
                return this.Width;
            }
            set
            {
                this.Width = value;
            }
        }
        public string ShapeDataDump
        {
            get
            {
                return String.Format("Circle (diameter:{0}) Area:{1}", this.Width, Area());
            }
        }

        //methods
        public double Area()
        {
            double radius = this.Width / 2;
            return radius * radius * Math.PI;
        }

        //constructors
        public Circle(double diameter)
        {
            this.Width = diameter;
        }
    }

    public class Square : IShape
    {
        //properties
        public double Width { get; set; }
        public double Height
        {
            get
            {
                return this.Width;
            }
            set 
            {
                this.Width = value;
            }
        }
        public string ShapeDataDump
        {
            get
            {
                return String.Format("Square (length:{0}) Area:{1}", this.Width, Area());
            }
        }

        //methods
        public double Area()
        {
            return this.Width * this.Width;
        }

        //constructors
        public Square(int width)
        {
            this.Width = width;
        }
    }
}
