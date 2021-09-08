using DeHaro.Calculadora.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeHaro.Calculadora
{
    public class RemoteOperationService : IOperable
    {
        public double doAddition(double[] numbers)
        {
            Console.WriteLine("REMOTE OP:");
            return numbers[0] + numbers[1];
        }

        public double doDivision(double[] numbers)
        {
            Console.WriteLine("REMOTE OP:");
            if (numbers[1] == 0)
            {
                throw new DivideByZeroException();
            }
            return numbers[0] / numbers[1];
        }

        public double doMultiplication(double[] numbers)
        {
            Console.WriteLine("REMOTE OP:");
            return numbers[0] * numbers[1];
        }

        public double doSubstraction(double[] numbers)
        {
            Console.WriteLine("REMOTE OP:");
            return numbers[0] - numbers[1];
        }
    }
}
