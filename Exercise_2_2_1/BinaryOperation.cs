using System;

namespace Exercise_2_1_2
{
    public class BinaryOperation : IOperation
    {
        private Func<double, double, double> _func;

        public BinaryOperation(Func<double, double, double> func)
        {
            _func = func;
        }

        public double Execute(double arg1, params double[] argn)
        {
            if(argn.Length != 1) throw new ArgumentException();

            return _func(arg1, argn[0]);
        }
    }
}