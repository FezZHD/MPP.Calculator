using System;
using System.ServiceModel;
using ServiceCalculator.Interfaces;

namespace ServiceCalculator
{
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
                var fault = new ExecutionFaults.ExecutionFaults("Result is NaN");
                throw new FaultException<ExecutionFaults.ExecutionFaults>(fault);
            }
            if (double.IsInfinity(value))
            {
                var fault = new ExecutionFaults.ExecutionFaults("Probably devide by zero");
                throw new FaultException<ExecutionFaults.ExecutionFaults>(fault);
            }
            return value;
        }
    }
}
