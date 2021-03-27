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

        //<summary>
        //    This api aceepts one argument that is id of employee and deletes that particular employee from the table.
        //</summary>
        public void DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
        }

        //<summary>
        //    This api accepts one argument that is id of employee and returns all the data of that particular employee.    
        //</summary>
        public EmployeesModel GetEmployee(int id)
        {
            return _employee.GetEmployee(id);
        }

        //<summary>
        //    This api returns the list of all the employess in the table.
        //</summary>
        public List<EmployeesModel> GetEmployees()
        {
            return _employee.GetEmployees();
        }

        //<summary>
        //    This api accepts one argument as object of EmployeesModel and inserts the employee's data in the database.
        //</summary>
        public void PostEmployee(EmployeesModel model)
        {
            _employee.PostEmployee(model);
        }

        //<summary>
        //    This api accepts two arguments employee's id and its other data and updates all the data of that particular employee.
        //</summary>
        public void PutEmployee(int id, EmployeesModel model)
        {
            _employee.PutEmployee(id, model);
        }

        //<summary>
        //    This api returns list of all the employees who are managers.
        //</summary>
        public List<EmployeesModel> GetManagers()
        {
            return _employee.GetManagers();
        }
    }
}
