using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator_WPF2
{
    class Program
    {
        public static string Equation()
        {
            double a = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("x^2 = ", "Quadratic equation input", ""));
            double b = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("x = ", "Quadratic equation input", ""));
            double c = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("c = ", "Quadratic equation input", ""));
            string resultatOutput;
            int dd;
            double x1;
            double x2;
            if (Ur2.Deskr(a, b, c) >= 0)
            {
                dd = Ur2.Gg(a, b, c, out x1, out x2);
                resultatOutput = dd + " x1 = " + x1 + " x2 = " + x2;
                return (resultatOutput);
            }
            else
            {
                dd = -1;
                resultatOutput = dd + " Корней нет";
                return (resultatOutput); 
            }
        }


    }
}



