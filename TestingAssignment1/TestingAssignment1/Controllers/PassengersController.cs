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


        /*
            This method is called when user wnats to add a new passenger. It accepts passengers data as input and adds the new passenger.
             */
        [HttpPost]
        public string AddPassenger(Passengers data)
        {
            return _Passenger.AddPassenger(data);
        }


        /*
            This method is called when user wnats to delete a passenger. It accepts passenger's unique id as input and deletes the passenger. 
             */
        [HttpDelete]
        public string DeletePassenger(int id)
        {
            return _Passenger.DeletePassenger(id);
        }



        /*
            This method is called when user wnats to edit a passenger. It accepts passenger's unique id and passenger's data as input and edits the 
            passenger. 
             */
        [HttpPut]
        public string EditPassenger(int id, Passengers data)
        {
            return _Passenger.EditPassenger(id, data);
        }

        /*
            This method is called when user wnats to get a passenger from its unique id. It accepts passenger's unique id as input and returns the 
            passenger details. 
             */
        [HttpGet]
        public Passengers GetPassenger(int id)
        {
            return _Passenger.GetPassenger(id);
        }

        /*
            This method is called when user wnats to get all the passengers. It returns the details of all the passengers.
             */
        [HttpGet]
        public IEnumerable<Passengers> GetPassengers()
        {
            return _Passenger.GetPassengers();
        }


    }
}
