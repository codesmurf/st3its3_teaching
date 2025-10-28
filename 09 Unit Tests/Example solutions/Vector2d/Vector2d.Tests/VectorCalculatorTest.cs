using System;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Execution;
using VectorCalculator;
using static NUnit.Framework.Assert;

namespace VectorCalculator.Test.Unit
{
    [TestFixture]
    public class VectorCalculatorTest
    {
        VectorCalculator vectorCalculator;

        [SetUp]
        public void Setup()
        {
            vectorCalculator = new VectorCalculator();
        }

        [Test]
        public void AddTwoVectors()
        {
            var v1 = new Vector(2, 1);
            var v2 = new Vector(2, 1);

            var result = vectorCalculator.Add(v1, v2);

            Assert.That(result.X, Is.EqualTo(4).Within(1E-15));
            Assert.That(result.Y, Is.EqualTo(2).Within(1E-15));
        }

        [TestCase(2, 1, 2, 1, 0, 0)]
        [TestCase(2, 1, 2, -1, 0, 2)]
        [TestCase(2.1, 1.0, 1.1, 0.8, 1.0, 0.2)]
        public void SubtractTwoVectors(double v1x, double v1y, double v2x,
            double v2y, double expectedX, double expectedY)
        {
            var v1 = new Vector(v1x, v1y);
            var v2 = new Vector(v2x, v2y);

            var result = vectorCalculator.Subtract(v1, v2);

            Assert.That(result.X, Is.EqualTo(expectedX).Within(1E-15));
            Assert.That(result.Y, Is.EqualTo(expectedY).Within(1E-15));
        }

        [Test]
        public void ScaleVector()
        {
            var v1 = new Vector(3, 4);

            var result = vectorCalculator.Scale(v1, 3);

            Assert.That(result.X, Is.EqualTo(9).Within(1E-15));
            Assert.That(result.Y, Is.EqualTo(12).Within(1E-15));
        }

        [Test]
        public void ScaleVectorNegative()
        {
            var v1 = new Vector(3, -4);

            var result = vectorCalculator.Scale(v1, 3);

            Assert.That(result.X, Is.EqualTo(9).Within(1E-14));
            Assert.That(result.Y, Is.EqualTo(-12).Within(1E-14));
        }

        [Test]
        public void DotProduct()
        {
            var v1 = new Vector(2, 1);
            var v2 = new Vector(2, -1);

            var result = vectorCalculator.Dot(v1, v2);

            Assert.That(result, Is.EqualTo(3).Within(1E-15));
        }

        public void DotProductZeroVector()
        {
            var v1 = new Vector(2, 1);
            var v2 = new Vector(0, 0);

            var result = vectorCalculator.Dot(v1, v2);

            Assert.That(result, Is.EqualTo(0).Within(1E-15));
        }
        
        [TestCase(5, 8, 2, -2, -0.22485, 0.0001)]
        [TestCase(2, 1, 2, -1, 0.6, 0.0000000001)]
        public void AngleBetweenTwoVectors(double v1x, double v1y, double v2x, double v2y, double expected, double delta)
        {
            var v1 = new Vector(v1x, v1y);
            var v2 = new Vector(v2x, v2y);

            double radian = vectorCalculator.Angle(v1, v2);


            Assert.That(radian, Is.EqualTo(expected).Within(delta));
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(3, 4, 5)]
        public void Magnitude(double vx, double vy, double expected)
        {
            var v = new Vector(vx, vy);

            Assert.That(vectorCalculator.Magnitude(v), Is.EqualTo(expected).Within(Double.Epsilon));
        }


    }
}
