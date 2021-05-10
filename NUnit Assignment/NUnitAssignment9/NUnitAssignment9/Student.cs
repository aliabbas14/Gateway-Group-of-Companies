using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitAssignment9
{

    public class StudentCrud
    {
        List<Student> stu = new List<Student>()
        {
            new Student(){Id=1,Name="ABC",Percentage=95.2,Department="Computer"},
            new Student(){Id=2,Name="XYZ",Percentage=85.6,Department="Mechanical"},
            new Student(){Id=3,Name="PQR",Percentage=98.7,Department="Chemical"}
        };

        public List<Student> GetStudents()
        {
            return stu;
        }

        public Student GetStudent(int id)
        {
            Student s = stu.Where(x => x.Id == id).FirstOrDefault();
            if (s == null)
                throw new Exception("Student not Found");
            return s;
        }

        public List<Student> GetStudentByDepartment(string dept)
        {
            List<Student> s = stu.Where(x => x.Department == dept).ToList();
            return s;
        }

        public string GetStudentName(int id)
        {
            Student s = stu.Where(x => x.Id == id).FirstOrDefault();
            return s.Name;
        }
        public int TotalStudent()
        {
            int c;
            c = GetStudents().Count();
            return c;
        }
        public Student GetStudentWithHighestPercentage()
        {
            Student s = new Student();
            s = GetStudents().OrderByDescending(x => x.Percentage).FirstOrDefault();
            return s;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }
        public string Department { get; set; }


    }
}
