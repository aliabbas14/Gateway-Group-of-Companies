using NBitcoin;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitAssignment7.Test
{
    [TestFixture]
    public class TestCases
    {
        Question1 q1 = new Question1();
        Question2 q2 = new Question2();
        [Test]
        public void TestSumOfnNumbersByWhileLoop()
        {
            // Arrange
            int n = 5;
            int expected = 15;

            // Act
            int result=q1.SumOfnNumbersByWhileLoop(n);

            // Assert
            Assert.Equals(expected, result);

        }

        [Test]
        [TestCase("+",5,10,15)]
        [TestCase("-", 10, 5, 5)]
        [TestCase("*", 5, 10, 50)]
        [TestCase("/", 50, 5, 10)]
        public void TestCalculatorBySwitchCase(string op,int x,int y,int expected)
        { 

            // Act
            int result = q1.CalculatorBySwitchCase(op,x,y);

            // Assert
            Assert.Equals(expected, result);
        }

        [Test]
        public void TestOddEvenByIfElse()
        {
            // Arrange
            int x = 6;
            string expected = "Even";

            // Act
            string result = q1.OddEvenByIfElse(x);

            // Assert
            Assert.Equals(expected, result);
        }

        [Test]
        public void TestSumOfArrayByForeachLoop()
        {
            // Arrange
            int[] x = { 1, 2, 3, 4, 5 };
            int expected = 15;

            // Act
            int result = q1.SumOfArrayByForeachLoop(x);

            // Assert
            Assert.Equals(expected, result);
        }

        [Test]
        public void TestSumOfnNumbersByForLoop()
        {
            // Arrange
            int x = 5;
            int expected = 15;

            // Act
            int result = q1.SumOfnNumbersByForLoop(x);

            // Assert
            Assert.Equals(expected, result);
        }

        [Test]
        public void TestgetStudentById()
        {
            //Arrange
            int id = 7;

            //Act + Assert
            Assert.Throws<Exception>(() => q2.getStudentById(id));
        }


        [Test]
        public void TestgetPercentageById()
        {
            // Arrange
            int x = 1;
            double expected = 95;
            // Act
            double result = q2.getPercentageById(x);

            // Assert
            Assert.Equals(expected, result);
        }

        [Test]
        public async void TestNumberOfStudents()
        {
            // Arrange
            int expected = 3;
        
            // Act
            int result = await q2.NumberOfStudents();

            // Assert
            Assert.Equals(expected, result);
        }

        [Test]
        public async void TestgetStudentNameWithHighestPercentage()
        {
            // Arrange
            string expected = "ABC";

            // Act
            string result = await q2.getStudentNameWithHighestPercentage();

            // Assert
            Assert.Equals(expected, result);
        }

    }
}
