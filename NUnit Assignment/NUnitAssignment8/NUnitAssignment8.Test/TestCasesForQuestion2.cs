using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NUnitAssignment8.Test
{
    [TestFixture]
    class TestCasesForQuestion2
    {

        [SetUp]
        public void Setup()
        {
        }

        Question2 q2 = new Question2();

        [OrderingTest(4)]
        public void TestgetStudents()
        {
            // Arrange


            // Act
            var result = q2.getStudents();

            // Assert
            result.Should().HaveCount(3);
        }

        [OrderingTest(2)]
        public void TestgetStudent()
        {
            // Arrange
            int id = 1;

            // Act
            var result = q2.getStudent(id);

            // Assert
            result.Name.Should().StartWith("A").And.EndWith("C").And.Contain("B").And.HaveLength(3);
        }

        [OrderingTest(0)]
        public void TestgetEmail()
        {
            // Arrange
            int id = 2;

            // Act
            var result = q2.getEmail(id);

            // Assert
            result.Should().Contain("@");
        }

        [OrderingTest(3)]
        public void TestgetPercentage()
        {
            // Arrange
            int id = 3;

            // Act
            var result = q2.getPercentage(id);

            // Assert
            result.Should().Be(75.6);
        }

        [OrderingTest(1)]
        public void TestgetStudentByDepartment()
        {
            // Arrange
            string department = "Computer";

            // Act
            var result = q2.getStudentByDepartment(department);

            // Assert
            result.Should().HaveCount(2);
        }

        [TestCaseSource(sourceName: "TestSource")]
        public void MainTest(TestStructure test)
        {
            test.Test();
        }
        public static IEnumerable<TestCaseData> TestSource
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                Dictionary<int, List<MethodInfo>> methods = assembly
                .GetTypes()
                .SelectMany(x => x.GetMethods())
                .Where(y => y.GetCustomAttributes().OfType<OrderingTestAttribute>().Any())
                .GroupBy(z => z.GetCustomAttribute<OrderingTestAttribute>().Order)
                .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
                foreach (var order in methods.Keys.OrderBy(x => x))
                {
                    foreach (var methodInfo in methods[order])
                    {
                        MethodInfo info = methodInfo;
                        yield return new TestCaseData(
                        new TestStructure
                        {
                            Test = () =>
                            {
                                object classInstance =
        Activator.CreateInstance(info.DeclaringType, null);
                                info.Invoke(classInstance, null);
                            }
                        }).SetName(methodInfo.Name);
                    }
                }
            }
        }
    }

    public class TestStructure
    {
        public Action Test;
    }
    public class OrderingTestAttribute : Attribute
    {
        public int Order { get; set; }
        public OrderingTestAttribute(int order)
        {
            this.Order = order;
        }
    }


}
