﻿using AspNetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAssignment.DAL.Interface
{
    public interface IEmployeeRepository
    {
        List<EmployeesModel> GetEmployees();

        EmployeesModel GetEmployee(int id);

        void PostEmployee(EmployeesModel model);

        void PutEmployee(int id, EmployeesModel model);

        void DeleteEmployee(int id);

        List<EmployeesModel> GetManagers();
    }
}
