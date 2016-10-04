using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sum()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Sum(x, y);

            Assert.IsTrue(sum == 30);
        }

        [TestMethod]
        public void Divide()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Divide(x, y);

            Assert.IsTrue(sum == 2);
        }

        [TestMethod]
        public void DivideZero()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 0;
            var sum = test.Divide(x, y);

            Assert.IsTrue(sum == 0);
        }

        [TestMethod]
        public void Multiply()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Multiply(x, y);

            Assert.IsTrue(sum == 200);
        }

        [TestMethod]
        public void Remainder()
        {
            var test = new Calc.Helper();
            int x = 22;
            int y = 10;
            var sum = test.Remainder(x, y);

            Assert.IsTrue(sum == 2);
        }

        [TestMethod]
        public void RemainderZero()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 0;
            var sum = test.Remainder(x, y);

            Assert.IsTrue(sum == 0);
        }

        [TestMethod]
        public void Subtract()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Subtract(x, y);

            Assert.IsTrue(sum == 10);
        }
    }
}
