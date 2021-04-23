using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitAssignment8.Test
{
    [TestFixture]
    public class TestCasesForQuestion1
    {
        Question1 q1 = new Question1();

        [Test]
        public void TestgetEmployees()
        {
            // Arrange
            

            // Act
            var result=q1.getEmployees();

            // Assert
            result.Should().HaveCount(3);
        }

        [Test]
        public void TestgetEmployee()
        {
            // Arrange
            int id = 1;

            // Act
            var result = q1.getEmployee(id);

            // Assert
            result.Name.Should().StartWith("A").And.EndWith("C").And.Contain("B").And.HaveLength(3);
        }

        [Test]
        public void TestgetSalary()
        {
            // Arrange
            int id = 2;

            // Act
            var result = q1.getSalary(id);

            // Assert
            result.Should().BeGreaterThan(0).And.Should().Be(7500);
        }

        [Test]
        public void TestgetAllPhone()
        {
            // Arrange
            
            // Act
            var result = q1.getAllPhone();

            // Assert
            result.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void TestgetEmployeeByDepartment()
        {
            // Arrange
            string department = "Technical";

            // Act
            var result = q1.getEmployeeByDepartment(department);

            // Assert
            result.Should().HaveCount(2);
        }

    }
}
