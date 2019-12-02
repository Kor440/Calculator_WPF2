using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator_WPF2
{
    class Ur2
    {
        public  static int Gg(double a, double b, double c, out double x1, out double x2)
        {
            double d = Deskr(a, b, c);

            if (d > 0)
            {
            x1 = (-b + Math.Sqrt(d)) / (2 * a);
            x2 = (-b - Math.Sqrt(d)) / (2 * a);
            return 1;
            }

            else
            {
                x1 = (-b + Math.Abs(d)) / (2 * a);
                x2 = x1;
                return 0;
            }
        }


      public static double Deskr(double a, double b, double c)
        {
            double d = b * b - 4 * a * c;
            return d;

        }
    }
}
