using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitAssignment8
{
    public class Question2
    {
        List<Student> Stu = new List<Student>()
        {
            new Student(){Id=1,Name="ABC",Email="abc@gmail.com",Percentage=95.7,Department="Computer"},
            new Student(){Id=2,Name="PQR",Email="pqr@gmail.com",Percentage=88.3,Department="Computer"},
            new Student(){Id=3,Name="XYZ",Email="xyz@gmail.com",Percentage=75.6,Department="Mechanical"},
        };

        public List<Student> getStudents()
        {
            return Stu;
        }

        public Student getStudent(int id)
        {
            return Stu.Where(x => x.Id == id).FirstOrDefault();
        }

        public string getEmail(int id)
        {
            return Stu.Where(x => x.Id == id).Select(x => x.Email).FirstOrDefault();
        }

        public double getPercentage(int id)
        {
            return Stu.Where(x => x.Id == id).Select(x => x.Percentage).FirstOrDefault();
        }

        public List<Student> getStudentByDepartment(string department)
        {
            return Stu.Where(x => x.Department == department).ToList();
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Percentage { get; set; }
        public string Department { get; set; }
    }
}
