using DeHaro.Calculadora.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DeHaro.Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {

            var CalculatorProvider = new ServiceCollection()
                .AddSingleton<IOperable, LocalOperationService> ()
                .AddTransient<RemoteOperationService>()
                .BuildServiceProvider();

            IOperable EJ1 = CalculatorProvider.GetService<IOperable>();
            RemoteOperationService EJ2 = CalculatorProvider.GetService<RemoteOperationService>();
            Console.WriteLine($"EJ1 = {EJ1.GetType()}");
            Console.WriteLine($"EJ2 = {EJ2.GetType()}");

            IOperable service;
            int election = 0;
            double[] numberList;
            Console.WriteLine("________________________________________");
            Console.WriteLine("|              CALCULATOR               |");
            Console.WriteLine("|_______________________________________|");
            while (true) 
            {

                Console.WriteLine("Welcome to Simple Calculator. Please write your operation");
                Console.WriteLine("TIP: If you write a non-number, will be register 0 bc yes");
                Console.WriteLine("1.- Adition");
                Console.WriteLine("2.- Subtraction");
                Console.WriteLine("3.- Multiplication ");
                Console.WriteLine("4.- Division");
                Int32.TryParse(Console.ReadLine(), out election);
                switch (election)
                {
                    case 0:
                        Console.WriteLine("Something went wrong, choose 1-4 option");
                        break;
                    case 1:
                        numberList = askNumbers();
                        service = CalculatorProvider.GetService<IOperable>();
                        Console.WriteLine($"Result: {service.doAddition(numberList)}");
                        break;
                    case 2:
                        numberList = askNumbers();
                        service = CalculatorProvider.GetService<IOperable>();
                        Console.WriteLine($"Result: {service.doSubstraction(numberList)}");
                        break;
                    case 3:
                        numberList = askNumbers();
                        service = CalculatorProvider.GetService<IOperable>();
                        Console.WriteLine($"Result: {service.doMultiplication(numberList)}");
                        break;
                    case 4:
                        numberList = askNumbers();
                        service = CalculatorProvider.GetService<IOperable>();
                        if(numberList[1] == 0)
                        {
                            Console.WriteLine("Result: +- oo");
                            break;
                        }
                        Console.WriteLine($"Result: {service.doDivision(numberList)}");
                        break;
                    default:
                        Console.WriteLine("Something went wrong, choose 1-4 option");
                        break;
                }
            }
        }

        public static double[] askNumbers()
        {
            double[] numbers = new double[]{ 0, 0 };
            Console.WriteLine("Select a number (positive or negative)");
            Double.TryParse(Console.ReadLine(), out numbers[0]);

            Console.WriteLine("Select second number");
            Double.TryParse(Console.ReadLine(), out numbers[1]);

            return numbers;
        }
    }
}
