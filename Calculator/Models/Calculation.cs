using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    static class Calculation
    {
        public static double Result(double a, double b, string operation)
        {
            double value;
            switch (operation)
            {
                case "+":
                    {
                        value = a + b;
                        break;
                    }
                case "-":
                    {
                        value = a - b;
                        break;
                    }
                case "/":
                    {
                        if (b!=0)
                        {
                            value = a / b;
                        }
                        else
                        {
                            value = 0;
                        }
                        break;
                    }
                case "*":
                    {
                        value = a * b;
                        break;
                    }
                default:
                    {
                        value = 0;
                        break;
                    }
            }
            return value;
        }
    }
}
