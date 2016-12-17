using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceCalculator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return ExecuteCalculation(() => a + b);
        }


        public double Substract(double a, double b)
        {
            return ExecuteCalculation(() => a - b);
        }

        public double Multiply(double a, double b)
        {
            return ExecuteCalculation(() => a * b);
        }

        public double Divide(double a, double b)
        {
            return ExecuteCalculation(() => a / b);
        }

        public double Sqrt(double a)
        {
            return ExecuteCalculation(() => Math.Sqrt(a));
        }


        private double ExecuteCalculation(Func<double> calculation)
        {
            var value = calculation();

            if (double.IsNaN(value))
            {
                
            }
            if (double.IsInfinity(value))
            {
                
            }
            return value;
        }
    }
}
