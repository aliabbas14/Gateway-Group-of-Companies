using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAssignment7
{
    public class Question2
    {
        List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id=1,
                Name="ABC",
                Percentage=95
            },
            new Student()
            {
                Id=2,
                Name="XYZ",
                Percentage=85.2
            },
            new Student()
            {
                Id=3,
                Name="PQR",
                Percentage=75.9
            }
        };

        public List<Student> getStudents()
        {
            return students;
        }

        public Student getStudentById(int id)
        {
             Student s=students.Find(x => x.Id == id);
             if(s==null)
             {
                throw new Exception("Student not Found");
             }
             else
            {
                return s;
            }
        }

        public double getPercentageById(int id)
        {
            Student s = students.Find(x => x.Id == id);

            return s.Percentage;
            
        }

        public async Task<int> NumberOfStudents()
        {
            int count = 0;
            await Task.Run(() =>
            {
                count = students.Count;
            });
            return count;
        }

        public async Task<string> getStudentNameWithHighestPercentage()
        {
            Student s = null;
            await Task.Run(() =>
            {
                s = students.OrderByDescending(x=>x.Percentage).FirstOrDefault();
            });
            return s.Name;
        }

    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }

    }
}
