using AspNetCoreAssignment.BAL.Interface;
using AspNetCoreAssignment.DAL.Interface;
using AspNetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAssignment.BAL
{
    public class EmployeeManager : IEmployeeManager
    {
        IEmployeeRepository _employee;

        public EmployeeManager(IEmployeeRepository employee)
        {
            _employee = employee;
        }


        public void DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
        }

        public EmployeesModel GetEmployee(int id)
        {
            return _employee.GetEmployee(id);
        }

        public List<EmployeesModel> GetEmployees()
        {
            return _employee.GetEmployees();
        }

        public void PostEmployee(EmployeesModel model)
        {
            _employee.PostEmployee(model);
        }

        public void PutEmployee(int id, EmployeesModel model)
        {
            _employee.PutEmployee(id, model);
        }

        public List<EmployeesModel> GetManagers()
        {
            return _employee.GetManagers();
        }
    }
}
