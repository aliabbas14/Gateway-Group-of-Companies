using AspNetCoreAssignment.BAL.Interface;
using AspNetCoreAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        ILogger _logger;

        public EmployeesController(IEmployeeManager employee,ILogger<EmployeesController> logger)
        {
            _employee = employee;
            _logger = logger;
        }


        //<summary>
        //    This api returns the list of all the employess in the table.
        //</summary>
        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try 
            {
                return Ok(_employee.GetEmployees());
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            
        }

        //<summary>
        //    This api accepts one argument that is id of employee and returns all the data of that particular employee.    
        //</summary>
        [HttpGet]
        [Route("GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                return Ok(_employee.GetEmployee(id));
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //<summary>
        //    This api accepts one argument as object of EmployeesModel and inserts the employee's data in the database.
        //</summary>
        [HttpPost]
        [Route("PostEmployee")]
        public IActionResult PostEmployee(EmployeesModel model)
        {
            try
            {
                _employee.PostEmployee(model);
                return Ok();
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //<summary>
        //    This api accepts two arguments employee's id and its other data and updates all the data of that particular employee.
        //</summary>
        [HttpPut]
        [Route("PutEmployee")]
        public IActionResult PutEmployee(int id,EmployeesModel model)
        {
            try
            {
                _employee.PutEmployee(id,model);
                return Ok();
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //<summary>
        //    This api aceepts one argument that is id of employee and deletes that particular employee from the table.
        //</summary>
        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            try 
            {
                _employee.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //<summary>
        //    This api returns list of all the employees who are managers.
        //</summary>
        [HttpGet]
        [Route("GetManagers")]
        public IActionResult GetManagers()
        {
            try 
            { 
                return Ok(_employee.GetManagers());
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
