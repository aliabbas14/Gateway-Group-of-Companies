﻿using AspNetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAssignment.BAL.Interface
{
    public interface IEmployeeManager
    {
        List<EmployeesModel> GetEmployees();

        EmployeesModel GetEmployee(int id);

        void PostEmployee(EmployeesModel model);

        void PutEmployee(int id,EmployeesModel model);

        void DeleteEmployee(int id);

        List<EmployeesModel> GetManagers();
    }
}
