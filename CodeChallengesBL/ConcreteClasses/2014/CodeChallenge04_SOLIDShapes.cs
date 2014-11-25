using CodeChallengesBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;

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

namespace CodeChallengesBL.ConcreteClasses
{
    public class CodeChallenge04_SOLIDShapes : ICodeChallenge
    {
        public string OutputResult(OrderedDictionary inputValues)
        {
            // original code above violates Separation of Concerns & Liskov Substitution principle
            // See Area() function below for refactored code

            var outputString = new StringBuilder();

            // NOTE: altering the sequence number (and consequently the input name attribute) for any ChallengeInput in the database will need to also be updated here
            string shapeCount = inputValues["solid-shapes5"] == null ? "" : inputValues["solid-shapes5"].ToString();
            
            string shapeClass1 = inputValues["solid-shapes10"] == null ? "" : inputValues["solid-shapes10"].ToString();
            string shapeClass2 = inputValues["solid-shapes30"] == null ? "" : inputValues["solid-shapes30"].ToString();
            string shapeClass3 = inputValues["solid-shapes50"] == null ? "" : inputValues["solid-shapes50"].ToString();

            string shape1Dimensions = inputValues["solid-shapes20"] == null ? "" : inputValues["solid-shapes20"].ToString();
            string shape2Dimensions = inputValues["solid-shapes40"] == null ? "" : inputValues["solid-shapes40"].ToString();
            string shape3Dimensions = inputValues["solid-shapes60"] == null ? "" : inputValues["solid-shapes60"].ToString();

            var userShapes = new Dictionary<int, IShape>
            {
                { 0, CreateUserShape(shapeClass1, shape1Dimensions) },
                { 1, CreateUserShape(shapeClass2, shape2Dimensions) },
                { 2, CreateUserShape(shapeClass3, shape3Dimensions) }
            };

            ValidateShapeData(userShapes, shapeCount, outputString);
            LogShapeData(userShapes, outputString);
            outputString.AppendLine("\nTotal Area is: " + Area(userShapes));

            return outputString.ToString();
        }

        public static IShape CreateUserShape(string shapeClass, string shapeWidthAndHeight)
        {
            string[] dimensions = shapeWidthAndHeight.ToLower().Split('x');
            string shapeWidth = dimensions[0];
            string shapeHeight = dimensions.Length > 1 ? dimensions[1] : shapeWidth;
            int shapeWidthNum;
            int shapeHeightNum;

            if (Int32.TryParse(shapeWidth, out shapeWidthNum) && 
                Int32.TryParse(shapeHeight, out shapeHeightNum) && 
                shapeWidthNum >= 0 && 
                shapeHeightNum >= 0 &&
                dimensions.Length <= 2)
            {
                Type type = Type.GetType("CodeChallengesBL.ConcreteClasses.CodeChallenge04_SOLIDShapes+" + shapeClass);
                return type == null ? new NullShape() : Activator.CreateInstance(type, shapeWidthNum, shapeHeightNum) as IShape;
            }
            else
            {
                return new NullShape();
            }
        }

        public static void ValidateShapeData(Dictionary<int, IShape> userShapes, string shapeCountStr, StringBuilder outputString)
        {
            int shapeCount;
            if (Int32.TryParse(shapeCountStr, out shapeCount))
            {
                for (int i = 0; i < shapeCount; i++)
                {
                    if (userShapes[i].Area() == -1) // check for NullShape
                    {
                        outputString.AppendLine(String.Format("Invalid shape dimensions for shape #{0}.  Try again.", i + 1));
                    }
                }
            }
            else
            {
                outputString.AppendLine("Invalid shape count.  Please try again.");
            }
        }

        public static double Area(Dictionary<int, IShape> shapes)
        {
            double area = 0;
            foreach (var shape in shapes.Values)
            {
                if (shape.Area() != -1) // check for NullShape
                {
                    area += shape.Area();
                }
            }
            return area;
        }

        public static void LogShapeData(Dictionary<int, IShape> shapes, StringBuilder outputString)
        {
            foreach (var shape in shapes.Values)
            {
                if (shape.Area() != -1) // check for NullShape
                {
                    outputString.AppendLine(shape.ShapeDataDump);
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
            public double Width { get; set; }
            public double Height { get; set; }
            public string ShapeDataDump
            {
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

            public Circle(double width, double height)
            {
                this.Width = width;
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
            public Square(double width)
            {
                this.Width = width;
            }

            public Square(double width, double height)
            {
                this.Width = width;
            }
        }

        public class NullShape : IShape
        {
            //properties
            public double Width
            {
                get
                {
                    return 0;
                }
                set
                {
                    this.Width = 0;
                }
            }

            public double Height
            {
                get
                {
                    return 0;
                }
                set
                {
                    this.Height = 0;
                }
            }

            public string ShapeDataDump
            {
                get 
                {
                    return "";
                }
            }

            //methods
            public double Area()
            {
                return -1;
            }
        }

    }
}
