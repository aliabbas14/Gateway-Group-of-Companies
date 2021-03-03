using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment1.Models;

namespace TestingAssignment1.DAL.Interface
{
    public interface IPassengersRepository
    {

        /*
            This method is called when user wnats to get all the passengers. It returns the details of all the passengers.
             */
        IEnumerable<Passengers> GetPassengers();


        /*
            This method is called when user wnats to get a passenger from its unique id. It accepts passenger's unique id as input and returns the 
            passenger details. 
             */
        Passengers GetPassenger(int id);


        /*
            This method is called when user wnats to add a new passenger. It accepts passengers data as input and adds the new passenger.
             */
        string AddPassenger(Passengers data);


        /*
            This method is called when user wnats to edit a passenger. It accepts passenger's unique id and passenger's data as input and edits the 
            passenger. 
             */
        string EditPassenger(int id, Passengers data);


        /*
            This method is called when user wnats to delete a passenger. It accepts passenger's unique id as input and deletes the passenger. 
             */
        string DeletePassenger(int id);
    }
}
