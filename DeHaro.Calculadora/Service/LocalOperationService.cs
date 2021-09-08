using DeHaro.Calculadora.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeHaro.Calculadora
{
    public class LocalOperationService : IOperable
    {
        public double doAddition(double[] numbers)
        {
            Console.WriteLine("LOCAL OP:");
            return Math.Round(numbers[0] + numbers[1], 2);
        }

        public double doDivision(double[] numbers)
        {
            Console.WriteLine("LOCAL OP:");
            if (numbers[1] == 0)
            {
                throw new DivideByZeroException();
            }
            /*
             * IF I WANT A INFINITE DIVISION METHOD
             * double acumulativo = numbers[0];
            for(int i = 0; i<numbers.Length; i++)
            {
                acumulativo = acumulativo / numbers[i + 1];
            }*/
            return Math.Round(numbers[0] / numbers[1], 2);
        }

        public double doMultiplication(double[] numbers)
        {
            Console.WriteLine("LOCAL OP:");
            return Math.Round(numbers[0] * numbers[1], 2);
        }

        public double doSubstraction(double[] numbers)
        {
            Console.WriteLine("LOCAL OP:");
            return Math.Round(numbers[0] - numbers[1], 2);
        }
    }
}
