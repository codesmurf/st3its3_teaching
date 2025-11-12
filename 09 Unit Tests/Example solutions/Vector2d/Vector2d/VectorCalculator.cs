using System;

namespace VectorCalculator
{
    public class VectorCalculator
    {

        public Vector Add(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public Vector Subtract(Vector v1, Vector v2)
        {
            return Add(v1, new Vector(-v2.X, -v2.Y));
        }

        public Vector Scale(Vector v1, int scalar)
        {
            return new Vector(v1.X * scalar, v1.Y * scalar);
        }

        public double Dot(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        public double Angle(Vector v1, Vector v2)
        {
            return Dot(v1, v2) / (Magnitude(v1) * Magnitude(v2));
        }

        public double Magnitude(Vector v)
        {
            return Math.Sqrt(v.X*v.X + v.Y*v.Y);
        }
    }
}
