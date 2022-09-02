using ShapeLib;
using System;
using Xunit;

namespace Tests
{


    public class CircleTest
    {
        [Theory]
        [InlineData(4.8, 72.4)]
        public void CalcCircleArea(double radius, double expectedArea)
        {
            // Arrange.
            var circle = new Circle(radius);

            // Act.
            var square = circle.GetArea();

            // Assert.
            Assert.Equal(square, expectedArea);
        }

        [Theory]
        [InlineData("Radius must be greater then zero")]
        public void CircleIncorrectInitial_ExpectedExeption(string expectedExeption)
        {
            // Arrange.
            Action act = () => new Circle(-1);

            // Act.
            var exception = Assert.Throws<ArgumentException>(act);

            // Assert.
            Assert.Equal(expectedExeption, exception.Message);
        }
    }


    public class TriangleTest
    {
        [Theory]
        [InlineData(5.0, 5.0, 4.0, 9.2)]
        public void CalcTriangleArea(double a, double b, double c, double expectedArea)
        {
            // Arrange.
            Triangle triangle = new Triangle(a, b, c);

            // Act.
            double result = triangle.GetArea();

            // Assert.
            Assert.Equal(expectedArea, result);
        }

        [Theory]
        [InlineData(-1.0, 5.0, 4.0, "One or more sides is zero or less")]
        [InlineData(100.0, 5.0, 4.0, "One side is greater than summ of two another sides")]
        public void TriangleIncorrectInitial_ExpectedExeption(double a, double b, double c, string expectedExeption)
        {
            // Arrange.
            Action act = () => new Triangle(a, b, c);

            // Act.
            var exception = Assert.Throws<ArgumentException>(act);

            // Assert.
            Assert.Equal(expectedExeption, exception.Message);
        }

        [Theory]
        [InlineData(5.0, 5.0, 7.1, true)]
        [InlineData(5.0, 5.0, 5.0, false)]
        public void CheckIsRightTriangle(double a, double b, double c, bool isRightTriangle)
        {
            // Arrange.
            Triangle triangle = new Triangle(a, b, c);

            // Act.
            bool result = triangle.IsRightTriangle();

            // Assert.
            Assert.Equal(result, isRightTriangle);
        }
    }

}