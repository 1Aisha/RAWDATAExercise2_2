using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_2_1_2
{
    /// <summary>
    /// The ReversePolishCalculator now has state you can change. Thus in this version 
    /// it would be better to instantiate a calculator when you need it.
    /// 
    /// </summary>
    public class ReversePolishCalculator
    {
        private readonly Dictionary<string, IOperation> _operations;

        public ReversePolishCalculator()
        {
            _operations = new Dictionary<string, IOperation>();

            AddOperation("+", (x, y) => x + y);
            AddOperation("-", (x, y) => x - y);
            AddOperation("*", (x, y) => x * y);
            AddOperation("/", (x, y) => x / y);
            AddOperation("^", (x, y) => Math.Pow(x, y));
            AddOperation("pow", (x, y) => Math.Pow(x, y));
            AddOperation("sqrt", x => Math.Sqrt(x));
            AddOperation("abs", x => Math.Abs(x));
        }

        public List<string> Operations { get { return _operations.Keys.ToList(); } }
        
        public void AddOperation(string name, Func<double, double> unaryOperation)
        {
            _operations[name] = new UnaryOperation(unaryOperation);
        }

        public void AddOperation(string name, Func<double, double, double> binaryOperation)
        {
            _operations[name] = new BinaryOperation(binaryOperation);
        }

        public void RemoveOperation(string name)
        {
            _operations.Remove(name);
        }

        public double Compute(string input)
        {
            double number = 0;
            var stack = new Stack<double>();
            if (string.IsNullOrEmpty(input))
            {
                return number;
            }
            
            foreach (var token in input.Split())
            {
                if (double.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    IOperation operation = null;
                    if (!_operations.TryGetValue(token, out operation))
                    {
                        throw new ArgumentException(string.Format("Operation '{0}' not found!", token));
                    }

                    if (operation is UnaryOperation)
                    {
                        if (stack.Count < 1)
                        {
                            throw new ArgumentException(string.Format("Missing operands for unary operation '{0}'", token));
                        }
                        var arg1 = stack.Pop();
                        stack.Push(operation.Execute(arg1));
                    }
                    else if (operation is BinaryOperation)
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException(string.Format("Missing operands for binary operation '{0}'", token));
                        }
                        var arg2 = stack.Pop();
                        var arg1 = stack.Pop();
                        stack.Push(operation.Execute(arg1, arg2));
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Operation '{0}' not supported", token));
                    }
                }
            }
            if (stack.Count > 1)
            {
                throw new ArgumentException(string.Format("Invalid expression: {0}", input));
            }
            return stack.Pop();
        }
    }

    
}