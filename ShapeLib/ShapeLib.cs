using System;

namespace ShapeLib
{
    public interface IAreaCalc
    {
        public double GetArea();
    }

    public class Circle : IAreaCalc
    {
        private readonly Lazy<double> area;

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius must be greater then zero");

            this.area = new Lazy<double>(() => Math.Round(Math.PI * Math.Pow(radius, 2), 1));
        }

        public double GetArea() => area.Value;
    }

    public class Triangle : IAreaCalc
    {
        private readonly Lazy<double> area;
        private readonly Lazy<bool> isRightTriangle;

        public Triangle(double sideA, double sideB, double sideC)
        {

            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("One or more sides is zero or less");

            if (sideA > (sideB + sideC) || sideB > (sideA + sideC) || sideC > (sideA + sideB))
                throw new ArgumentException("One side is greater than summ of two another sides");


            this.area = new Lazy<double>(() =>
            {
                var halfPerim = (sideA + sideB + sideC) / 2;
                return Math.Round(Math.Sqrt(halfPerim * (halfPerim - sideA) * (halfPerim - sideB) * (halfPerim - sideC)), 1);
            });

            this.isRightTriangle = new Lazy<bool>(() =>
                Math.Round(sideA, 1) == Math.Round(Math.Sqrt(Math.Pow(sideB, 2) + Math.Pow(sideC, 2)), 1)
                || Math.Round(sideB, 1) == Math.Round(Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideC, 2)), 1)
                || Math.Round(sideC, 1) == Math.Round(Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2)), 1));
        }

        public double GetArea() => area.Value;

        public bool IsRightTriangle() => isRightTriangle.Value;
    }
}
