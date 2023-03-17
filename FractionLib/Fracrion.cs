using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FractionLib
{
    public class Fraction
    {
        public int numerator { get; private set; }
        public int denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));

            int gcd = GCD(numerator, denominator);
            this.numerator = numerator / gcd;
            this.denominator = denominator / gcd;
            if (this.denominator < 0)
            {
                this.denominator *= -1;
                this.numerator *= -1;
            }
        }
        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.denominator);

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int gcd = GCD(a.denominator, b.denominator);
            return new Fraction(a.numerator / gcd * b.denominator + b.numerator / gcd * a.denominator, a.denominator / gcd * b.denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
        {
            int gcdAD = GCD(a.numerator, b.denominator);
            int gcdBC = GCD(a.denominator, b.numerator);
            return new Fraction((a.numerator / gcdAD) * (b.numerator / gcdBC), (a.denominator / gcdBC) * (b.denominator / gcdAD));
        }

        public static Fraction GetInverseForMultiply(Fraction a)
                => new Fraction(a.denominator, a.numerator);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return a * GetInverseForMultiply(b);
        }

        public void Pow(int power)
        {
            if (power < 0)
            {
                int num = numerator;
                numerator = denominator;
                denominator = num;
                if (denominator < 0)
                {
                    numerator *= -1;
                    denominator *= -1;
                }
                power *= -1;
            }
                numerator = (int)Math.Pow(numerator, power);
                
                denominator = (int)Math.Pow(denominator, power);

        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Fraction other = (Fraction)obj;
            return denominator == other.denominator && numerator == other.numerator;
        }

        public override int GetHashCode()
        {
            return denominator.GetHashCode() ^ numerator.GetHashCode();
        }

        public override string ToString() => $"{numerator} / {denominator}";

        private static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a = a % b;
                else
                    b = b % a;
            }
            return a + b;
        }
    }
}
