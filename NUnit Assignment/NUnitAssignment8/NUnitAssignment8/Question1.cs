using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitAssignment8
{
    public class Question1
    {
        List<Employee> Emp = new List<Employee>()
        {
            new Employee(){Id=1,Name="ABC",Salary=5000,Phone="9856452563",Department="HR"},
            new Employee(){Id=2,Name="PQR",Salary=7500,Phone="8545256398",Department="Technical"},
            new Employee(){Id=3,Name="XYZ",Salary=9250,Phone="7896251245",Department="Technical"},
        };

        public List<Employee> getEmployees()
        {
            return Emp;
        }

        public Employee getEmployee(int id)
        {
            return Emp.Where(x => x.Id == id).FirstOrDefault() ;
        }

        public int getSalary(int id)
        {
            return Emp.Where(x => x.Id == id).Select(x=>x.Salary).FirstOrDefault();
        }

        public List<string> getAllPhone()
        {
            return Emp.Select(x => x.Phone).ToList();
        }

        public List<Employee> getEmployeeByDepartment(string department)
        {
            return Emp.Where(x=>x.Department==department).ToList();
        }
    }

    public class Employee
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
    }
}
