using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticGUI
{
    public class fraction
    {
        int numerator; //分子
        int denominator; //分母
        public fraction(int x, int y)
        {
            numerator = x;
            denominator = y;
        }

        public int GetNumerator()
        {
            return numerator;
        }

        public int GetDenominator()
        {
            return denominator;
        }

        public static int FracionGetGCD(int a, int b)
        {
            return (a % b == 0) ? b : FracionGetGCD(b, a % b);
        }

        public static fraction operator +(fraction A, fraction B)
        {
            int x, y, z = 1;
            x = A.numerator * B.denominator + A.denominator * B.numerator;
            y = A.denominator * B.denominator;
            z = FracionGetGCD(x, y);
            return new fraction(x / z, y / z);
        }

        public static fraction operator -(fraction A, fraction B)
        {
            int x, y, z = 1;
            x = A.numerator * B.denominator - A.denominator * B.numerator;
            y = A.denominator * B.denominator;
            z = FracionGetGCD(x, y);
            return new fraction(x / z, y / z);
        }

        public static fraction operator *(fraction A, fraction B)
        {
            int x, y, z = 1;
            x = A.numerator * B.numerator;
            y = A.denominator * B.denominator;
            z = FracionGetGCD(x, y);
            return new fraction(x / z, y / z);
        }

        public static fraction operator /(fraction A, fraction B)
        {
            int x, y, z = 1;
            x = A.numerator * B.denominator;
            y = A.denominator * B.numerator;
            z = FracionGetGCD(x, y);
            return new fraction(x / z, y / z);
        }

        public static fraction operator ^(fraction A, fraction B)
        {
            int x = 1, y = 1, xx, yy, z = 1, t = 0;
            t = B.numerator / B.denominator;
            xx = A.numerator;
            yy = A.denominator;
            if (yy != 0 && t == 0)
            {
                return new fraction(1, 1);
            }
            else if (B.numerator / B.denominator == 1)
            {
                return new fraction(A.numerator, A.denominator);
            }
            else
            {
                while (t > 0)
                {
                    x = x * xx;
                    y = y * yy;
                    t--;
                }
                z = FracionGetGCD(x, y);
                return new fraction(x / z, y / z);
            }
        }

        public static bool operator <(fraction A, fraction B)
        {
            int x, y;
            bool z;
            x = A.numerator * B.denominator - A.denominator * B.numerator;
            y = A.denominator * B.denominator;
            z = (x > 0 && y < 0) || (x < 0 && y > 0);
            return z;
        }

        public static bool operator >(fraction A, fraction B)
        {
            int x, y;
            bool z;
            x = A.numerator * B.denominator - A.denominator * B.numerator;
            y = A.denominator * B.denominator;
            z = (x > 0 && y < 0) || (x < 0 && y > 0);
            return z;
        }

        public static bool operator ==(fraction A, fraction B)
        {
            fraction C;
            bool z = false;
            C = A / B;
            if (C.numerator / C.denominator == 1) z = true;
            return z;
        }

        public static bool operator !=(fraction A, fraction B)
        {
            fraction C;
            bool z = false;
            C = A / B;
            if (C.numerator / C.denominator != 1) z = true;
            return z;
        }
    }
}


