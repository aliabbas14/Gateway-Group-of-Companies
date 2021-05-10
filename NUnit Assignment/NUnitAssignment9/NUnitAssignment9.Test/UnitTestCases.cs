using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitAssignment9.Test
{
    public class UnitTestCases
    {
        StudentCrud _stu;
        

        public UnitTestCases()
        {
            _stu = new StudentCrud();
        }


        [Test]
        public void TestStudentsInDepartmentComputer()
        {
            //Arrange
            string dept = "Computer";
            //Act

            List<Student> stu = _stu.GetStudentByDepartment(dept);
            //Assert
            Assert.That(stu, Is.CheckDesignation(dept));
        }
        [Test]
        public void TestStudentsInDepartmentMechanical()
        {
            //Arrange
            string dept = "Mechanical";
            //Act

            List<Student> stu = _stu.GetStudentByDepartment(dept);
            //Assert
            Assert.That(stu, Is.CheckDesignation(dept));
        }
        [Test]
        public void TestGetStudents()
        {
            //Arrange
            var stu = new List<Student>()
            {
               new Student(){Id=1,Name="ABC",Percentage=95.2,Department="Computer"},
                new Student(){Id=2,Name="XYZ",Percentage=85.6,Department="Mechanical"}
            };
            var mock = new Mock<StudentCrud>();
            mock.Setup(x => x.GetStudents()).Returns(stu);
            //Act
            Operations o = new Operations(mock.Object);
            List<Student> s = _stu.GetStudents();
            //Assert
            Assert.That(Is.Equals(s.Count, stu.Count));
        }
        [Test]
        public void TestStudentsInDepartmentChemical()
        {
            //Arrange
            string dept = "Chemical";
            var stu = new List<Student>()
            {
                new Student(){Id=3,Name="PQR",Percentage=98.7,Department="Chemical"},
            };
            var mock = new Mock<StudentCrud>();
            mock.Setup(x => x.GetStudentByDepartment(dept)).Returns(stu);
            //Act
            Operations o = new Operations(mock.Object);
            int actual = o.TotalStudentByDepartment(dept);
            //Assert
            Assert.That(actual, NUnit.Framework.Is.EqualTo(1));
        }
       
        [Test]
        public void TestTotalStudentsForComputer()
        {
            //Arrange

            var mock = new Mock<StudentCrud>();
            mock.Setup(x => x.TotalStudent()).Returns(1);
            //Act
            Operations o = new Operations(mock.Object);
            int actual = o.TotalEmployees();
            //Assert
            Assert.That(actual, NUnit.Framework.Is.EqualTo(1));
        }
        [Test]
        public void TestGetStudentWithHighestPercentage()
        {
            //Arrange
            var stu = new Student()
            {
                Id = 1,
                Name = "ABC",
                Percentage = 95.2,
                Department = "Computer"
            };
            var mock = new Mock<StudentCrud>();
            mock.Setup(x => x.GetStudentWithHighestPercentage()).Returns(stu);
            //Act
            Operations o = new Operations(mock.Object);
            Student actual = o.GetStudentWithHighestPercentage();
            //Assert
            Assert.That(Is.Equals(actual.Id, stu.Id));
        }
    }
}
