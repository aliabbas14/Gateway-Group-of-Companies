using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAssignment1.DAL.Interface;
using TestingAssignment1.Models;

namespace TestingAssignment1.Controllers
{
    public class PassengersController : ApiController
    {
        IPassengersRepository _Passenger;

        public PassengersController(IPassengersRepository Passenger)
        {
            _Passenger = Passenger;
        }

        [HttpPost]
        public string AddPassenger(Passengers data)
        {
            return _Passenger.AddPassenger(data);
        }

        [HttpDelete]
        public string DeletePassenger(int id)
        {
            return _Passenger.DeletePassenger(id);
        }

        [HttpPut]
        public string EditPassenger(int id, Passengers data)
        {
            return _Passenger.EditPassenger(id, data);
        }

        [HttpGet]
        public Passengers GetPassenger(int id)
        {
            return _Passenger.GetPassenger(id);
        }

        [HttpGet]
        public IEnumerable<Passengers> GetPassengers()
        {
            return _Passenger.GetPassengers();
        }


    }
}
