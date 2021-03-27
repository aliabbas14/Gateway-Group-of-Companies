﻿using AspNetCoreAssignment.DAL.Interface;
using AspNetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreAssignment.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _db;

        public EmployeeRepository(EmployeeContext db)
        {
            _db = db;
        }

        //<summary>
        //    This api aceepts one argument that is id of employee and deletes that particular employee from the table.
        //</summary>
        public void DeleteEmployee(int id)
        {
            var emp=_db.Employees.Where(x => x.Id == id).FirstOrDefault();
            _db.Employees.Remove(emp);
            _db.SaveChanges();

        }

        //<summary>
        //    This api accepts one argument that is id of employee and returns all the data of that particular employee.    
        //</summary>
        public EmployeesModel GetEmployee(int id)
        {
            var e=_db.Employees.Where(x => x.Id == id).FirstOrDefault();
            var res = new EmployeesModel()
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Department = e.Department,
                Phone = e.Phone,
                Email = e.Email,
                IsManager = e.IsManager,
                Manager = e.Manager
            };

            return res;
        }

        //<summary>
        //    This api returns the list of all the employess in the table.
        //</summary>
        public List<EmployeesModel> GetEmployees()
        {
            List<EmployeesModel> emp = new List<EmployeesModel>();

            foreach(var e in _db.Employees.ToList())
            {
                var res = new EmployeesModel() {
                    Id = e.Id,
                    Name=e.Name,
                    Salary=e.Salary,
                    Department=e.Department,
                    Phone=e.Phone,
                    Email=e.Email,
                    IsManager=e.IsManager,
                    Manager=e.Manager
                };

                emp.Add(res);
            }

            return emp;
             
        }

        //<summary>
        //    This api accepts one argument as object of EmployeesModel and inserts the employee's data in the database.
        //</summary>
        public void PostEmployee(EmployeesModel model)
        {
            var emp = new Employees() {
                Name = model.Name,
                Salary = model.Salary,
                Department = model.Department,
                IsManager=model.IsManager,
                Manager=model.Manager,
                Phone=model.Phone,
                Email=model.Email
                
                
            };
            _db.Employees.Add(emp);
            _db.SaveChanges();
        }

        //<summary>
        //    This api accepts two arguments employee's id and its other data and updates all the data of that particular employee.
        //</summary>
        public void PutEmployee(int id, EmployeesModel model)
        {
            var emp=_db.Employees.Where(x => x.Id == id).FirstOrDefault();
            emp.Name = model.Name;
            emp.Salary = model.Salary;
            emp.Department = model.Department;
            emp.Phone = model.Phone;
            emp.Email = model.Email;
            emp.IsManager = model.IsManager;
            emp.Manager = model.Manager;

            _db.SaveChanges();

        }

        //<summary>
        //    This api returns list of all the employees who are managers.
        //</summary>
        public List<EmployeesModel> GetManagers()
        {
            

            List<EmployeesModel> emp = new List<EmployeesModel>();

            foreach (var e in _db.Employees.Where(x => x.IsManager == true).Select(x => x.Name).ToList()) {
                var res = new EmployeesModel() {
                    
                    Name = e,
       
                };

                emp.Add(res);
            }

            return emp;
        }

    }
}
