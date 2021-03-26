using AspNetCoreAssignment.BAL.Interface;
using AspNetCoreAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class EmployeesController : ControllerBase
    {
        IEmployeeManager _employee;

        public EmployeesController(IEmployeeManager employee)
        {
            _employee = employee;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(_employee.GetEmployees());
        }

        [HttpGet]
        [Route("GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            return Ok(_employee.GetEmployee(id));
        }

        [HttpPost]
        [Route("PostEmployee")]
        public IActionResult PostEmployee(EmployeesModel model)
        {
            _employee.PostEmployee(model);
            return Ok();
        }

        [HttpPut]
        [Route("PutEmployee")]
        public IActionResult PutEmployee(int id,EmployeesModel model)
        {
            _employee.PutEmployee(id,model);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetManagers")]
        public IActionResult GetManagers()
        {
            return Ok(_employee.GetManagers());
        }


    }
}
