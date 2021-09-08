using DeHaro.Calculadora;
using DeHaro.Calculadora.Interface;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace Test.Calculadora
{
    public class Tests
    {
/*        [SetUp]
        public void Setup()
        {
        }*/

        [Test]
        public void TestAditionBasic()
        {
            IOperable service = createServiceProvider();
            double[] numbers= new double[2] {5,5};
            Assert.AreEqual(10, service.doAddition(numbers));
        }
        [Test]
        public void TestMonkeyAditionBasic()
        {
            IOperable service = createServiceProvider();
            double[] numbers = new double[2] { 5, 5 };
            Assert.AreNotEqual(11, service.doAddition(numbers));
        }

        [Test]
        public void TestAditionWithDecimals()
        {
            IOperable service = createServiceProvider();
            double[] numbers = new double[2] { 5.5, 10.23 };
            Assert.AreEqual(15.73, service.doAddition(numbers));
        }

        [Test]
        public void TestAditionNegativeNmbers()
        {
            IOperable service = createServiceProvider();
            double[] numbers = new double[2] { -10, 5 };
            Assert.AreEqual(-5, service.doAddition(numbers));
        }

        [Test]
        public void TestSubstraction1()
        {
            IOperable service = createServiceProvider();
            double[] numbers = new double[2] { 5, 5 };
            Assert.AreEqual(0, service.doSubstraction(numbers));
        }

        [Test]
        public void TestMultiplication1()
        {
            IOperable service = createServiceProvider();
            double[] numbers = new double[2] { 5, 5 };
            Assert.AreEqual(25, service.doMultiplication(numbers));
        }

        [Test]
        public void TestDivision1()
        {
            IOperable service = createServiceProvider();
            double[] numbers = new double[2] { 10, 5};
            Assert.AreEqual(2, service.doDivision(numbers));         
        }

        [Test]
        public void TestDivisionByZero()
        {
            IOperable service = createServiceProvider();
            double[] numbers = new double[2] { 10, 0 };
            Assert.Throws<DivideByZeroException>(() => service.doDivision(numbers));
        }

        [Test]
        public void TestServiceCollection()
        {
            var CalculatorProvider = new ServiceCollection()
                .AddSingleton<IOperable, LocalOperationService>()
                .AddTransient<RemoteOperationService>()
                .BuildServiceProvider();
            IOperable serviceProvider = CalculatorProvider.GetService<IOperable>();
            RemoteOperationService serviceRemote = CalculatorProvider.GetService<RemoteOperationService>();
            Assert.IsInstanceOf<IOperable>(serviceProvider);
            Assert.IsInstanceOf<RemoteOperationService>(serviceRemote);
        }
        
        private IOperable createServiceProvider()
        {
            var CalculatorProvider = new ServiceCollection()
                .AddSingleton<IOperable, LocalOperationService>()
                .AddTransient<RemoteOperationService>()
                .BuildServiceProvider();

            return CalculatorProvider.GetService<IOperable>();
        }
    }
}