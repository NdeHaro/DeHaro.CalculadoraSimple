using System;
using System.Collections.Generic;
using System.Text;

namespace DeHaro.Calculadora.Interface
{
    public interface IOperable
    {
        public double doAddition(double[] numbers);
        public double doSubstraction(double[] numbers);
        public double doMultiplication(double[] numbers);
        public double doDivision(double[] numbers);

    }
}
