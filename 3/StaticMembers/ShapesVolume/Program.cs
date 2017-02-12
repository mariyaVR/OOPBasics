using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesVolume
{
    public class TriangularPrism
    {
        public double baseSide;
        public double height;
        public double length;

        public TriangularPrism(double baseSide, double height, double length)
        {
            this.baseSide = baseSide;
            this.height = height;
            this.length = length;
        }
    }

    public class Cube
    {
        public double side;

        public Cube(double side)
        {
            this.side = side;
        }
    }

    public class Cylinder
    {
        public double radius;
        public double height;

        public Cylinder(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
        }
    }

    public static class VolumeCalculator
    {
        public static double TriangularPrismVolume(TriangularPrism shape)
        {
            return shape.baseSide * shape.height * shape.length / 2;
        }

        public static double CubeVolume(Cube shape)
        {
            return shape.side * shape.side * shape.side;
        }

        public static double CylinderVolume(Cylinder shape)
        {
            return shape.radius * shape.radius * shape.height * Math.PI;
        }
    }

    class Startup
    {
        static StringBuilder result = new StringBuilder();

        static void Main()
        {
            var input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                var inputArgs = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (inputArgs[0])
                {
                    case "Cube":
                        var cube = new Cube((double.Parse(inputArgs[1])));
                        result.AppendLine($"{VolumeCalculator.CubeVolume(cube):F3}");
                        break;
                    case "Cylinder":
                        var cylinder = new Cylinder(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]));
                        result.AppendLine($"{VolumeCalculator.CylinderVolume(cylinder):F3}");
                        break;
                    case "TrianglePrism":
                        var trianglePrism = new TriangularPrism(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));
                        result.AppendLine($"{VolumeCalculator.TriangularPrismVolume(trianglePrism):F3}");
                        break;
                }

                input = Console.ReadLine();
            }

            Console.Write(result);
        }
    }
}
