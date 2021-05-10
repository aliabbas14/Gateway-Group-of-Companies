using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitAssignment9
{
    public class Operations
    {
        StudentCrud _stu;
        public Operations(StudentCrud stu)
        {
            _stu = stu;
        }
        public int TotalStudents()
        {
            return _stu.TotalStudent();
        }
        public int TotalStudentByDepartment(string dept)
        {
            int result = _stu.GetStudentByDepartment(dept).Count;
            return result;
        }
        public Student GetStudentWithHighestPercentage()
        {
            return _stu.GetStudentWithHighestPercentage();
        }
        public List<Student> GetStudents()
        {
            return _stu.GetStudents();
        }
    }
}
