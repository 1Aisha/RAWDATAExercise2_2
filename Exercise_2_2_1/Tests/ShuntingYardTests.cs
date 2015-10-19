using System;
using NUnit.Framework;

namespace Exercise_2_1_2.Tests
{
    public class ShuntingYardTests
    {

        // using the operations from https://en.wikipedia.org/wiki/Shunting-yard_algorithm
        // as input for the tests

        private ReversePolishCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new ReversePolishCalculator();
        }

        [Test]
        public void Parse_Number_ReturnNumber()
        {
            Assert.AreEqual("3", ShuntingYard.Parse("3"));
        }

        [Test]
        public void Parse_NumberAddition_ReturnRpn()
        {
            Assert.AreEqual("3 4 +", ShuntingYard.Parse("3 + 4"));
            Assert.AreEqual(7, Calculate("3 + 4"));
        }

        [Test]
        public void Parse_AdditionAndMultiplication_ReturnRpn()
        {
            Assert.AreEqual("3 4 2 * +", ShuntingYard.Parse("3 + 4 * 2"));
            Assert.AreEqual(11, Calculate("3 + 4 * 2"));
        }

        [Test]
        public void Parse_ExpressionInParentheses_ReturnRpn()
        {
            Assert.AreEqual("1 5 -", ShuntingYard.Parse("( 1 - 5 )"));
            Assert.AreEqual(-4, Calculate("1 5 -"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_MissingLeftParenthesesInExpression_ThrowsException()
        {
            ShuntingYard.Parse("1 - 5 )");
        }

        [Test]
        public void Parse_CheckLeftAssociative_ReturnBool()
        {
            Assert.True(ShuntingYard.CheckLeftAssociative("+", "-"));
            Assert.True(ShuntingYard.CheckLeftAssociative("+", "*"));
            Assert.False(ShuntingYard.CheckLeftAssociative("*", "-"));
            Assert.True(ShuntingYard.CheckLeftAssociative("*", "/"));
            Assert.True(ShuntingYard.CheckLeftAssociative("*", "^"));
            Assert.False(ShuntingYard.CheckLeftAssociative("^", "*"));
        }

        [Test]
        public void Parse_CheckRightAssociative_ReturnBool()
        {
            Assert.False(ShuntingYard.CheckRightAssociative("^", "-"));
            Assert.False(ShuntingYard.CheckRightAssociative("^", "*"));
            Assert.False(ShuntingYard.CheckRightAssociative("^", "+"));
            Assert.False(ShuntingYard.CheckRightAssociative("^", "/"));
        }

        [Test]
        public void Parse_MixedExpressionWithParentheses_ReturnRpn()
        {
            Assert.AreEqual("3 4 2 * 1 5 - / +", ShuntingYard.Parse("3 + 4 * 2 / ( 1 - 5 )"));
            Assert.AreEqual(1, Calculate("3 + 4 * 2 / ( 1 - 5 )"));
        }

        [Test]
        public void Parse_MixedExpressionWithParenthesesAndPower_ReturnRpn()
        {
            Assert.AreEqual("3 4 2 * 1 5 - 2 3 ^ ^ / +", ShuntingYard.Parse("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3"));
        }

        [Test]
        public void Parse_Sqrt_ReturnRpn()
        {
            Assert.AreEqual("16 sqrt", ShuntingYard.Parse("sqrt ( 16 )"));
            Assert.AreEqual(4, Calculate("sqrt ( 16 )"));
        }

        [Test]
        public void Parse_Pow_ReturnRpn()
        {
            Assert.AreEqual("2 8 pow", ShuntingYard.Parse("pow ( 2 , 8 )"));
            Assert.AreEqual(256, Calculate("pow ( 2 , 8 )"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_MissingLeftParentheses_ThrowsException()
        {
            ShuntingYard.Parse("pow 2 , 8 )");
        }


        // Helper methods 
        // to make the tests more readable
        private double Calculate(string expression)
        {
            return _calculator.Compute(ShuntingYard.Parse(expression));
        }
    }
}