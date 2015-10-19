using System;
using NUnit.Framework;

namespace Exercise_2_1_2.Tests
{
    public class ReversePolishCalculatorTests
    {
        private ReversePolishCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new ReversePolishCalculator();
        }
        [Test]
        public void Compute_WithEmptyString_ReturnZero()
        {
            Assert.AreEqual(0, _calculator.Compute(""));
        }

        [Test]
        public void Compute_WithNullString_ReturnZero()
        {
            Assert.AreEqual(0, _calculator.Compute(null));
        }

        [Test]
        public void Compute_WithSingleNumber_ReturnTheNumber()
        {
            Assert.AreEqual(7, _calculator.Compute("7"));
        }

        [Test]
        public void Compute_WithAdditionOfTwoNumbers_ReturnTheSum()
        {
            Assert.AreEqual(12, _calculator.Compute("7 5 +"));
        }

        [Test]
        public void Compute_WithSubstractionOfTwoNumbers_ReturnTheDifference()
        {
            Assert.AreEqual(2, _calculator.Compute("7 5 -"));
        }

        [Test]
        public void Compute_WithMultiplicationOfTwoNumbers_ReturnTheProduct()
        {
            Assert.AreEqual(35, _calculator.Compute("7 5 *"));
        }

        [Test]
        public void Compute_WithDivisionOfTwoNumbers_ReturnTheQuotient()
        {
            Assert.AreEqual(2, _calculator.Compute("10 5 /"));
        }

        [Test]
        public void Compute_WithNumberRaisedToExponent_ReturnThePower()
        {
            Assert.AreEqual(100000, _calculator.Compute("10 5 ^"));
        }

        [Test]
        public void Compute_512Plus4TimesPlus3Minus_Return14()
        {
            Assert.AreEqual(14, _calculator.Compute("5 1 2 + 4 * + 3 -"));
        }

        [Test]
        public void Compute_Sqrt16_Return4()
        {
            Assert.AreEqual(4, _calculator.Compute("16 sqrt"));
        }

        [Test]
        public void Compute_Pow2To8_Return256()
        {
            Assert.AreEqual(256, _calculator.Compute("2 8 pow"));
            
        }

        [Test]
        public void Compute_AbsMinus5_Return5()
        {
            Assert.AreEqual(5, _calculator.Compute("-5 abs"));
        }

        [Test]
        public void Operations__ReturnTheAvailableOperations()
        {
            Assert.AreEqual("+,-,*,/,^,pow,sqrt,abs", string.Join(",", _calculator.Operations));
        }

        [Test]
        public void Add_NewOperation_MakeTheOperationAvailable()
        {
            _calculator.AddOperation("cos", x => Math.Cos(x));
            Assert.AreEqual("+,-,*,/,^,pow,sqrt,abs,cos", string.Join(",", _calculator.Operations));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Compute_InvalidExpression_ThrowsException()
        {
            _calculator.Compute("5 1");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Compute_InvalidExpression2_ThrowsException()
        {
            _calculator.Compute("+ 1");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Compute_InvalidOperation_ThrowsException()
        {
            _calculator.Compute("5 1 xxx");
        }
    }
}