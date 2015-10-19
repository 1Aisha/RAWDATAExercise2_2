using System;

namespace Exercise_2_1_2
{
    public class UnaryOperation : IOperation
    {
        private readonly Func<double, double> _func;

        public UnaryOperation(Func<double, double> func)
        {
            _func = func;
        }

        public double Execute(double arg1, params double[] argn)
        {
            return _func(arg1);
        }
    }
}